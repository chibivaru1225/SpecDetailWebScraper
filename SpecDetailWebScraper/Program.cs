using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;

namespace SpecDetailWebScraper
{
    public static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            SpecDetailWebScraper appbase = new SpecDetailWebScraper();
            appbase.DetailScraper.Args = args.ToList();
            appbase.Run(args);
        }
    }

    public class SpecDetailWebScraper : WindowsFormsApplicationBase
    {
        public FormDetailScraper DetailScraper;

        /// <summary>
        /// コンストラクタ
        /// シングルインスタンス・アプリケーションを作り、その設定をさせるためのクラス
        /// </summary>
        public SpecDetailWebScraper() : base()
        {
            this.EnableVisualStyles = true;
            this.IsSingleInstance = true;
            this.DetailScraper = new FormDetailScraper();
            this.DetailScraper.StartPosition = FormStartPosition.CenterScreen;
            this.MainForm = this.DetailScraper;//スタートアップフォームを設定
            this.StartupNextInstance += new StartupNextInstanceEventHandler(SpecDetailWebScraper_StartupNextInstance);
        }

        /// <summary>
        /// 新しいインスタンスが生成されようとしているときのイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpecDetailWebScraper_StartupNextInstance(object sender, StartupNextInstanceEventArgs e)
        {
            //最前面表示にはしない
            e.BringToForeground = false;

            //引数を引数キャッシュに貯めさせる
            this.DetailScraper.Args = e.CommandLine.ToList();
        }
    }
}
