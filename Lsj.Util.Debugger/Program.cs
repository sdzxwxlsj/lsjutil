﻿
using Lsj.Util.Net.Web;
using Lsj.Util.Net.Web.Exceptions;
using Lsj.Util.Net.Web.Listener;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lsj.Util.Data.LDB;
using Lsj.Util.Net;
using Lsj.Util.Text;
using Lsj.Util.HtmlBuilder;
using System.IO;
using Lsj.Util.Logs;
using System.Runtime.InteropServices;
using Lsj.Util.Office;
using Microsoft.Office.Interop.Word;
using System.Drawing;
using Lsj.Util.Office.Word;

namespace Lsj.Util.Debugger
{
    class Program
    {
        /*     public static void Main()

             {
              Logs.LogProvider.Default.Config.UseConsole = true;
                 try
                 {
                     var x = new WebServer();
                     var a = new SocketListener();
                     a.Port = 85;
                     x.AddListener(a);
                     x.Start();
                 }
                 catch(Exception e)
                 {
                     Console.Write(e);
                 }
                 Console.ReadLine();
             }*/

        /*   public static void Main()
           {
               var a = new LDBFile("test.ldb",false);
               a.Config.DBName = "test";
               a.Save();
               Console.ReadLine();
           }*/
        /*public static void Main()
        {
            var client = new WebHttpClient();
            Console.Write(client.Get(new URI("http://127.0.0.1")).ConvertFromBytes(Encoding.UTF8));
            Console.ReadLine();
        }*/





        //public static void Main()
        //{
        //    var cpu = new Intel8086();




        //    Console.ReadLine();
        ////}
        //public static void Main()
        //{
        //    var page = HtmlParser.ParsePage(File.ReadAllText(@"c:\test.html"));
        //    LogProvider.Default.Config.UseConsole = true;
        //    Console.Write(page.ToString());



        //    Console.ReadLine();
        //}
        //public static void Main()
        //{
        //    var page = HtmlParser.ParsePage(File.ReadAllText(@"c:\test.html"));
        //    LogProvider.Default.Config.UseConsole = true;
        //    Console.Write(page.ToString());



        //    Console.ReadLine();
        //}
        public static void Main()
        {
            //	IntPtr a = Marshal.AllocHGlobal(1000000000);
            //	Console.ReadLine();
            using (var doc = new WordDocument())
            {
                doc.SetDocPaper(WdPaperSize.wdPaperA4);
                doc.SetDocMargin(doc.MillimetersToPoints(38.1), doc.MillimetersToPoints(31.9), doc.MillimetersToPoints(27), doc.MillimetersToPoints(19.4));
                doc.SetAppendStyle(size: 28, alignment: eParagraphAlignment.Center);
                doc.AppendLine();
                doc.AppendLine();

                doc.SetAppendStyle(size: 22, fontname: "华文中宋", alignment: eParagraphAlignment.Center, fontcolor: Color.FromArgb(68, 84, 106));
                doc.AppendLine("中小学生学业诊断分析系统");
                doc.AppendLine("学业支持子系统个体测评报告");

                doc.SetAppendStyle(size: 16, alignment: eParagraphAlignment.Center);
                doc.AppendBlankLine(9);

                doc.SetAppendStyle(size: 16, fontname: "宋体", alignment: eParagraphAlignment.Center, fontcolor: Color.Black, underline: eUnderline.Single);
                doc.AppendLine("学校： 	远东仁民");

                doc.SetAppendStyle(size: 16, alignment: eParagraphAlignment.Center);
                doc.AppendLine();

                doc.SetAppendStyle(size: 16, fontname: "宋体", alignment: eParagraphAlignment.Center, fontcolor: Color.Black, underline: eUnderline.Single);
                doc.AppendLine("姓名： 	  李端沐");
                doc.AppendPage();

                doc.SetAppendStyle(size: 24, fontname: "宋体", alignment: eParagraphAlignment.Center, fontcolor: Color.FromArgb(46, 116, 181));
                doc.AppendLine("目    录");

                doc.SetAppendStyle(size: 14, fontname: "宋体", alignment: eParagraphAlignment.Left, fontcolor: Color.Black);
                doc.AppendTableOfContents();

                doc.AppendSection();
                var section = doc.Sections[1];
                section.AddPageNumberAtFooter();

                doc.SetAppendStyle(style: eBuiltinStyle.Heading1);
                doc.AppendLine("a");
                doc.SetAppendStyle(style: eBuiltinStyle.Heading2);
                doc.AppendLine("a");


                doc.TablesOfContents[0].Update();
                doc.TablesOfContents[0].Select();
                doc.SetSelectionStyle(size: 14, fontname: "宋体", alignment: eParagraphAlignment.Left, fontcolor: Color.Black);

                doc.SetAppendStyle(size: 24, fontname: "华文中宋", alignment: eParagraphAlignment.Center, fontcolor: Color.Black, backgroundcolor: Color.AliceBlue, bold: true,style:eBuiltinStyle.Heading1);
                doc.AppendLine("心理测评知识普及");

                doc.SetAppendStyle(style: eBuiltinStyle.BodyText);
                doc.AddTable(3, 3);
                doc.Tables[0].AddTableBorder(Color.Red,Color.Red);
                doc.Tables[0].SetTitle("table1");
                doc.Tables[0].SetRowStyle(1, Color.AliceBlue);

                doc.AddTable(3, 4);
                Console.WriteLine( doc.Tables.Count());
                doc.Tables[1].MergeCell(1, 1, 1, 2);
                doc.Tables[1].AddTableBorder();
                doc.Tables[1].CellText(1, 1, "test");
                doc.Tables[1].SetCellStyle(1, 1, backgroundcolor: Color.AliceBlue, bold: true);
                

                doc.SaveAs(@"D:\temp.docx");
                Console.ReadLine();
                doc.Close();

            }

        }
    }

}
