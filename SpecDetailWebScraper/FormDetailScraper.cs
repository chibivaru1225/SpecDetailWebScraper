using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpecDetailWebScraper
{
    /// <summary>
    /// 詳細取得画面
    /// </summary>
    public partial class FormDetailScraper : Form
    {
        /// <summary>
        /// マウスフラグ
        /// </summary>
        private bool mouseflag;

        /// <summary>
        /// 検索ワード画面を開いているかどうか
        /// </summary>
        public bool ShowSetSearchWord { get; set; }

        /// <summary>
        /// 検索ワード、引数などのキャッシュ
        /// </summary>
        private List<String> argscache;

        /// <summary>
        /// 今検索中の引数リスト
        /// </summary>
        private List<String> args;

        /// <summary>
        /// 引数リスト
        /// </summary>
        public List<String> Args
        {
            get
            {
                return args;
            }
            set
            {
                args = value;

                //バックグラウンドワーカーが動作していない時のみ稼働させる
                if (bgw1 != null && bgw1.IsBusy == false && args != null && args.Count > 0)
                {
                    bgw1.RunWorkerAsync(args);
                    tssl1.Text = "データ取得中";
                }
                else
                {
                    //それ以外はキャッシュにためておく
                    argscache.AddRange(value);
                }
            }
        }

        //検索結果のキャッシュ
        public List<Result> Results;

        //現在選択中の検索結果 フォルダ開くときに使う
        public string selectingcode = string.Empty;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FormDetailScraper()
        {
            InitializeComponent();

            //初期化
            Results = new List<Result>();
            mouseflag = false;
            ShowSetSearchWord = false;
            argscache = new List<string>();

            //引数つきで起動された場合はこのタイミングでバックグラウンドワーカーを稼働させる
            if (bgw1 != null && args != null && args.Count > 0)
                bgw1.RunWorkerAsync(args);
        }

        /// <summary>
        /// 検索履歴の表示をセットする
        /// </summary>
        private void SetSearchHistory()
        {
            ClearSearchHistory();

            //Resultから表示用のListViewItemを作っていく
            foreach (var result in Results)
            {
                String[] items = { String.Empty, result.Word, ResultType.DispName(result.Type), result.Time.ToString("HH:mm"), result.ResultNumber.ToString() };
                ListViewItem lvi = new ListViewItem(items);

                lvSearchHistory.Items.Add(lvi);
            }

            //一番下の行(=最新のデータ)を選択中にする
            if (lvSearchHistory.Items.Count > 0)
            {
                lvSearchHistory.Items[lvSearchHistory.Items.Count - 1].Selected = true;
            }
        }

        /// <summary>
        /// 検索履歴の表示をクリアする
        /// </summary>
        private void ClearSearchHistory()
        {
            lvSearchHistory.Items.Clear();
        }

        /// <summary>
        /// リストビューのカラム幅変更時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvSearchHistory_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            //カラム幅は変更できない
            e.Cancel = true;
            e.NewWidth = lvSearchHistory.Columns[e.ColumnIndex].Width;
        }

        /// <summary>
        /// 検索履歴の選択中の行が変更されたときのイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvSearchHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            //表示中アイテムが0件の場合はなにもしない
            if (lvSearchHistory.Items.Count <= 0)
                return;

            //選択中アイテムがない場合はなにもしない
            if (lvSearchHistory.SelectedItems.Count <= 0)
                return;

            //インデックスを取得
            int i = lvSearchHistory.SelectedItems[0].Index;

            //検索履歴がない場合はなにもしない
            if (this.Results.Count < i)
                return;

            //検索結果をクリアする
            ClearSearchResult();

            //検索履歴の表示したい行のタイプによって動作を決める
            switch (this.Results[i].Type)
            {
                //URL直打ちの場合は1件のみの検索結果になる
                case ResultTypes.DirectURL:
                    String[] ditems = { String.Empty, this.Results[i].ResultSpec.Title };
                    ListViewItem dlvi = new ListViewItem(ditems);

                    //親のインデックスをタグに保持する
                    dlvi.Tag = i;

                    lvSearchResult.Items.Add(dlvi);
                    break;
                //検索ワードの場合は複数件検索結果が存在するので、表示用データを作成する
                case ResultTypes.Search:
                    foreach (var item in this.Results[i].ResultSearch.Specs)
                    {
                        String[] sitems = { String.Empty, item.Title };
                        ListViewItem slvi = new ListViewItem(sitems);

                        //親のインデックスをタグに保持する
                        slvi.Tag = i;

                        lvSearchResult.Items.Add(slvi);
                    }
                    break;
            }

            //一番上の行を選択中にする
            if (lvSearchResult.Items.Count > 0)
            {
                lvSearchResult.Items[0].Selected = true;
            }
        }

        /// <summary>
        /// 検索結果の表示をクリアする
        /// </summary>
        private void ClearSearchResult()
        {
            lvSearchResult.Items.Clear();
            selectingcode = string.Empty;
        }

        /// <summary>
        /// 検索結果の選択中の行が変更されたときのイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvSearchResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            //表示中アイテムが0件の場合はなにもしない
            if (lvSearchResult.Items.Count <= 0)
                return;

            //選択中アイテムがない場合はなにもしない
            if (lvSearchResult.SelectedItems.Count <= 0)
                return;

            //インデックスを取得する
            int i;
            int l = lvSearchResult.SelectedItems[0].Index;

            //検索履歴が選択されているか調べる
            //選択されていない場合はタグから親のインデックスを取得する
            if (lvSearchHistory.SelectedItems.Count <= 0)
                i = (int)lvSearchResult.SelectedItems[0].Tag;
            else
                i = lvSearchHistory.SelectedItems[0].Index;

            //インデックスより検索履歴件数が少ない場合は戻る
            if (this.Results.Count < i || this.Results[i].ResultNumber < l)
                return;

            //表示をリセットする
            ClearResultPrev();

            //表示するデータを取得する
            var spec = new ResultSpec();

            switch (this.Results[i].Type)
            {
                case ResultTypes.DirectURL:
                    spec = this.Results[i].ResultSpec;
                    break;
                case ResultTypes.Search:
                    spec = this.Results[i].ResultSearch.Specs[l];
                    break;
            }

            selectingcode = spec.SearchWord ?? spec.ItemID;
            string str = String.Empty;

            foreach (var sp in spec.Item)
            {
                str += sp.Key + "\t" + sp.Value + "\r\n";
            }

            //画面に設定
            lblTitleDetail.Text = spec.Title;
            lblURLDetail.Text = spec.URL;
            txtResultPrev.Text = str;
        }
        /// <summary>
        /// 結果データをクリアする
        /// </summary>
        private void ClearResultPrev()
        {
            txtResultPrev.Clear();
        }

        /// <summary>
        /// 結果データフォーカス時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtResultPrev_Enter(object sender, EventArgs e)
        {
            txtResultPrev.SelectAll();

            if (Control.MouseButtons != MouseButtons.None)
                mouseflag = true;
        }

        /// <summary>
        /// 結果データフォーカス時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtResultPrev_MouseDown(object sender, MouseEventArgs e)
        {
            if (mouseflag == true)
            {
                txtResultPrev.SelectAll();
                mouseflag = false;
            }
        }

        /// <summary>
        /// リストビューのカラム幅変更時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvSearchResult_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            //カラム幅は変更できない
            e.Cancel = true;
            e.NewWidth = lvSearchResult.Columns[e.ColumnIndex].Width;
        }

        /// <summary>
        /// バックグラウンドワーカーの作業
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgw1_DoWork(object sender, DoWorkEventArgs e)
        {
            List<Result> results = new List<Result>();

            if (e.Argument is List<String> args)
            {
                foreach (var arg in args)
                {
                    try
                    {
                        if (Util.IsUrl(arg) == false)
                        {
                            var urls = Search.GetSearchResult(arg).Result;
                            Thread.Sleep(1000);

                            ResultSearch search = new ResultSearch();

                            foreach (var url in urls.URLs)
                            {
                                try
                                {
                                    var s = ResultSpec.GetTextAsync(Util.SpecUrl(url), arg).Result;

                                    search.Specs.Add(s);

                                    Thread.Sleep(1000);
                                }
                                catch
                                {
                                }
                            }

                            Result result = new Result(search);
                            result.Time = DateTime.Now;
                            result.Word = arg;

                            results.Add(result);
                        }
                        else
                        {
                            var t = arg.TrimEnd('/');
                            var s = ResultSpec.GetTextAsync(Util.SpecUrl(t)).Result;
                            Thread.Sleep(1000);

                            Result result = new Result(s);
                            result.Time = DateTime.Now;
                            result.Word = arg;

                            results.Add(result);
                        }
                    }
                    catch
                    {
                    }
                }

                Console.WriteLine(String.Join(",", args));
            }

            e.Result = results;
        }

        /// <summary>
        /// バックグラウンドワーカー稼働終了時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgw1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null && e.Result is List<Result> results)
            {
                //検索が正常に終了した場合
                Results.AddRange(results);
                SetSearchHistory();
                tssl1.Text = "データ取得完了";
                txtResultPrev.Focus();
            }
            else
            {
                tssl1.Text = "データ取得失敗";
            }

            //引数キャッシュに残っている場合は、古い順(=FIFO順)に取得させる
            if (argscache.Count > 0)
            {
                tssl1.Text = "データ取得中";
                bgw1.RunWorkerAsync(argscache);
                argscache.Clear();
            }
        }

        /// <summary>
        /// ファンクションキーなどの動作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormDetailScraper_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                //F1が押されたら検索ワード指定画面を表示する
                if (ShowSetSearchWord == false)
                {
                    var frm = new FormSetSearchWord();
                    frm.DetailScraper = this;
                    frm.StartPosition = FormStartPosition.CenterScreen;

                    frm.Show();
                    ShowSetSearchWord = true;
                }
            }
            else if (e.KeyCode == Keys.F2)
            {
                //F2が押されたらクリップボードにコピーする
                if (txtResultPrev.Text.Trim() != String.Empty)
                {
                    Clipboard.SetText(txtResultPrev.Text.Trim());
                    tssl1.Text = "クリップボードにコピーしました";
                }
                else
                {
                    tssl1.Text = "データがないのでクリップボードにコピーしませんでした";
                }
            }
            else if (e.KeyCode == Keys.F3)
            {
                //F3が押されたらクリップボードにコピーし、画面を閉じる
                if (txtResultPrev.Text.Trim() != String.Empty)
                {
                    Clipboard.SetText(txtResultPrev.Text.Trim());
                    this.Close();
                }
                else
                {
                    tssl1.Text = "データがないのでクリップボードにコピーしませんでした";
                }
            }
            else if (e.KeyCode == Keys.F4)
            {
                //F4が押されたら表示しているページの画像をすべて保存する？

                //現状はマイピクチャの価格.comフォルダを開く(ない場合は作ってから表示する)
                //string folderpath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + @"\価格.com\" + selectingcode;
                string folderpath = Util.NetWorkFolderPath + selectingcode;

                try
                {
                    if (!System.IO.Directory.Exists(folderpath))
                        System.IO.Directory.CreateDirectory(folderpath);

                    System.Diagnostics.Process.Start("EXPLORER.EXE", folderpath);
                }
                catch
                {
                    MessageBox.Show("フォルダが開けません。社内ネットワークに接続していない可能性があります。");
                }
            }
        }

        private void btnF1_Click(object sender, EventArgs e)
        {
            //F1が押されたら検索ワード指定画面を表示する
            if (ShowSetSearchWord == false)
            {
                var frm = new FormSetSearchWord();
                frm.DetailScraper = this;
                frm.StartPosition = FormStartPosition.CenterScreen;

                frm.Show();
                ShowSetSearchWord = true;
            }
        }

        private void btnF2_Click(object sender, EventArgs e)
        {
            //F2が押されたらクリップボードにコピーする
            if (txtResultPrev.Text.Trim() != String.Empty)
            {
                Clipboard.SetText(txtResultPrev.Text.Trim());
                tssl1.Text = "クリップボードにコピーしました";
            }
            else
            {
                tssl1.Text = "データがないのでクリップボードにコピーしませんでした";
            }
        }

        private void btnF3_Click(object sender, EventArgs e)
        {
            //F3が押されたらクリップボードにコピーし、画面を閉じる
            if (txtResultPrev.Text.Trim() != String.Empty)
            {
                Clipboard.SetText(txtResultPrev.Text.Trim());
                this.Close();
            }
            else
            {
                tssl1.Text = "データがないのでクリップボードにコピーしませんでした";
            }
        }

        private void btnF4_Click(object sender, EventArgs e)
        {
            //F4が押されたら表示しているページの画像をすべて保存する？

            //現状はマイピクチャの価格.comフォルダを開く(ない場合は作ってから表示する)
            //string folderpath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + @"\価格.com\" + selectingcode;
            string folderpath = Util.NetWorkFolderPath + selectingcode;

            try
            {
                if (!System.IO.Directory.Exists(folderpath))
                    System.IO.Directory.CreateDirectory(folderpath);

                System.Diagnostics.Process.Start("EXPLORER.EXE", folderpath);
            }
            catch
            {
                MessageBox.Show("フォルダが開けません。社内ネットワークに接続していない可能性があります。");
            }
        }
    }
}
