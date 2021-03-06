﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApplication1
{
    public partial class GoodsPopularity : UserControl
    {
        public GoodsPopularity()
        {
            InitializeComponent();
        }

        OleDbCommand cmd = new OleDbCommand();
        DataSet sal = new DataSet();


        string ordercode = "";

        protected DataTable GetDataOrder()
        {
            OleDbConnection cn = new OleDbConnection("Provider=microsoft.ace.oledb.12.0;" + @"Data Source=.\DB\IM2.accdb;");

            string DSCheck = DateStart.Text;
            string DECheck = DateEnd.Text;

            DataTable dt = new DataTable();
            ordercode = "";

            if (DateStart.Text == "    /  /" && DateEnd.Text == "    /  /")     //日付指定　＃-'
            {
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT 注文日,商品ID FROM 注文テーブル WHERE 入金済み in (true) ORDER BY 注文日", cn);
                Msg.Text = "全てのデータ";
                da.Fill(dt);
            }
            else if (DateEnd.Text == "    /  /")
            {
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT 注文日,商品ID FROM 注文テーブル WHERE 注文日 Between #" + DateStart.Text + "#  AND 入金済み in (true) ORDER BY 注文日", cn);
                Msg.Text = DSCheck + "のデータ";
                da.Fill(dt);
            }
            else if (DateStart.Text == "    /  /")
            {
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT 注文日,商品ID FROM 注文テーブル WHERE 注文日 Between #" + DateEnd.Text + "# AND 入金済み in (true) ORDER BY 注文日", cn);
                Msg.Text = DECheck + "のデータ";
                da.Fill(dt);
            }
            else
            {
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT 注文日,商品ID FROM 注文テーブル WHERE 注文日 Between #" + DateStart.Text + "# and #" + DateEnd.Text + "# AND 入金済み in (true) ORDER BY 注文日", cn);
                Msg.Text = DSCheck + "～" + DECheck + "のデータ";
                da.Fill(dt);
            }

            DataTable order = new DataTable();   //データテーブルオブジェクトを作成
            DataRow dtRow;



            order.Columns.Add("注文日", Type.GetType("System.DateTime"));
            order.Columns.Add("商品ID", Type.GetType("System.String"));

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dtRow = order.NewRow();
                dtRow["注文日"] = dt.Rows[i][0];      //DBから取得したdtの注文日を示す行の行番号と列番号
                ordercode += dt.Rows[i][1];
                order.Rows.Add(dtRow);
            }

            return dt;    //データテーブルを返す
        }

        private void DateSelectCount_Click(object sender, EventArgs e)
        {
            string DSCheck = DateStart.Text;
            string DECheck = DateEnd.Text;
            int check;
            check = 0;
            DateTime cc;
            //日付の精査
            if (DateStart.Text == "    /  /" && DateEnd.Text == "    /  /")     //日付指定　＃-'
            {

            }
            else
            {
                if (DateEnd.Text == "    /  /")
                {
                    for (int i = 0; i < DSCheck.Length; i++)
                    {
                        if (DSCheck.Substring(i, 1) == " ")
                        {
                            check = 1;
                        }
                    }
                    if (DateTime.TryParse(DSCheck, out cc))
                    {

                    }
                    else
                    {
                        check = 1;

                    }
                }
                else if (DateStart.Text == "    /  /")
                {
                    for (int i = 0; i < DSCheck.Length; i++)
                    {
                        if (DECheck.Substring(i, 1) == " ")
                        {
                            check = 1;
                        }
                    }
                    if (DateTime.TryParse(DECheck, out cc))
                    {

                    }
                    else
                    {
                        check = 1;

                    }
                }
                else
                {
                    if (DateTime.TryParse(DSCheck, out cc))
                    {

                    }
                    else
                    {
                        check = 1;

                    }
                    if (DateTime.TryParse(DECheck, out cc))
                    {

                    }
                    else
                    {
                        check = 1;

                    }
                }

            }

            if (check == 0)
            {
                chart1.Series.Clear();
                DataTable order = GetDataOrder();
                DataSet sal = new DataSet();

                //Goodsテーブルから商品ID,商品名,単価を商品ID順に取り出す
                OleDbConnection cn = new OleDbConnection("Provider=microsoft.ace.oledb.12.0;" + @"Data Source=.\DB\IM2.accdb;");
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT 商品ID,商品名 FROM 商品マスタ ORDER BY 商品ID", cn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                DataTable goods = sal.Tables.Add("goods");
                DataRow dtRow;

                var count = new int[dt.Rows.Count];
                int total;

                goods.Columns.Add("商品ID", Type.GetType("System.String"));
                goods.Columns.Add("商品名", Type.GetType("System.String"));
                goods.Columns.Add("数量", Type.GetType("System.Double"));


                //配列の初期化
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    count[i] = 0;
                }
                //数量計算
                for (int i = 0; i < ordercode.Length; i++)
                {
                    if (ordercode.Substring(i, 1) != ",")
                    {
                        count[int.Parse(ordercode.Substring(i, 1)) - 1] += 1;
                    }
                }

                //合計金額を初期化
                total = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dtRow = goods.NewRow();
                    dtRow["商品ID"] = dt.Rows[i][0];      //DBから取得したdtの商品IDを示す行の行番号と列番号
                    dtRow["商品名"] = dt.Rows[i][1];  //DBから取得したdtの商品名を示す行の行番号と列番号
                    dtRow["数量"] = count[i];
                    total += count[i];
                    if (count[i] != 0)
                    {
                        goods.Rows.Add(dtRow);
                    }
                }

                /*
                 * DataViewを使用してDataTableの並び替えを行う
                 */
                // 並び替える
                DataView dv = new DataView(goods);
                // 降順
                dv.Sort = "数量";
                // 昇順
                //dv.Sort = "数量 DESC";

                // 並び替え後のデータをDataTableに戻す
                goods = dv.ToTable();
                //dataGridView1.DataSource = sal;
                //dataGridView1.DataMember = "goods";

                chart1.Series.Clear();
                chart1.Titles.Clear();
                chart1.Titles.Add("商品別の売上数");
                chart1.Series.Add("数量");


                chart1.Series["数量"].ChartType = SeriesChartType.Bar;       //Bar
                chart1.Series["数量"].IsValueShownAsLabel = true;
                chart1.Series["数量"].Color = Color.Green;
                chart1.ChartAreas["ChartArea1"].AxisY.Interval = 5;

                chart1.DataSource = goods;         //チャートに表示するデータテーブルを設定
                chart1.Series["数量"].XValueMember = goods.Columns["商品名"].ColumnName;
                chart1.Series["数量"].YValueMembers = goods.Columns["数量"].ColumnName;
                chart1.DataBind();   //データバインド
                TotalMsg.Text = "売上合計数：" + total.ToString() + "個";
                this.chart1.Visible = true;
                Msg.Visible = true;
                TotalMsg.Visible = true;
            }
            else
            {
                Msg.Text = "未選択";
                TotalMsg.Text = "";
                this.chart1.Visible = false;
                MessageBox.Show("入力された日付は存在しません", "入力エラー");
            }
        }

        //フォームのイメージを保存する変数
        private Bitmap memoryImage;

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]

        private static extern bool BitBlt(IntPtr hdcDest,
            int nXDest, int nYDest, int nWidth, int nHeight,
            IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);

        private const int SRCCOPY = 0xCC0020;

        /// <summary>
        /// コントロールのイメージを取得する
        /// </summary>
        /// <param name="ctrl">キャプチャするコントロール</param>
        /// <returns>取得できたイメージ</returns>
        public Bitmap CaptureControl(Control ctrl)
        {
            Graphics g = ctrl.CreateGraphics();
            Bitmap img = new Bitmap(ctrl.ClientRectangle.Width,
                ctrl.ClientRectangle.Height, g);
            Graphics memg = Graphics.FromImage(img);
            IntPtr dc1 = g.GetHdc();
            IntPtr dc2 = memg.GetHdc();
            BitBlt(dc2, 0, 0, img.Width, img.Height, dc1, 0, 0, SRCCOPY);
            g.ReleaseHdc(dc1);
            memg.ReleaseHdc(dc2);
            memg.Dispose();
            g.Dispose();
            img.RotateFlip(RotateFlipType.Rotate90FlipNone);
            return img;
        }

        //PrintDocument1のPrintPageイベントハンドラ
        private void PrintDocument1_PrintPage(object sender,
             System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }

        private void PrintForm(GoodsPopularity goodsPopularity)
        {
            //フォームのイメージを取得する
            memoryImage = CaptureControl(goodsPopularity);
            //フォームのイメージを印刷する
            System.Drawing.Printing.PrintDocument PrintDocument1 =
                 new System.Drawing.Printing.PrintDocument();
            PrintDocument1.PrintPage +=
                 new System.Drawing.Printing.PrintPageEventHandler(
                 PrintDocument1_PrintPage);
            PrintDocument1.Print();

            memoryImage.Dispose();
        }

        private void printing_Click(object sender, EventArgs e)
        {
            PrintForm(this);
        }

        private void GoodsPopularity_Load(object sender, EventArgs e)
        {
            this.ActiveControl = this.DateStart;
        }

        private void GoodsPopularity_VisibleChanged(object sender, EventArgs e)
        {
            this.ActiveControl = this.DateStart;
            Msg.Text = "指定したい期間を入力後ボタンをクリック！";
            TotalMsg.Visible = false;
            chart1.Visible = false;
            DateStart.Text = "";
            DateEnd.Text = "";
        }

        private void Btnclean_Click(object sender, EventArgs e)
        {
            this.ActiveControl = this.DateStart;
            Msg.Text = "指定したい期間を入力後ボタンをクリック！";
            TotalMsg.Visible = false;
            chart1.Visible = false;
            DateStart.Text = "";
            DateEnd.Text = "";
        }
    }
}
