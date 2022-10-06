using System;
using System.Diagnostics;
using System.IO;

namespace HomeTask_1_3_GraphUsing
{
    public class PdfCreator
    {
        string dot, output;

        public PdfCreator(string dot, string output)
        {
            this.dot = dot;
            this.output = output;
        }

        public void CreatePDF()
        {
            String tmp = this.output + ".dot";
            using (StreamWriter writer = File.CreateText(tmp))
                writer.Write(this.dot);
            using (Process process = new Process())
            {
                process.StartInfo.UseShellExecute = true;
                process.StartInfo.FileName = "dot";
                process.StartInfo.Arguments = "-Tpdf " + tmp + " -o " + output + ".pdf";
                process.Start();
                while (!process.HasExited)
                    process.Refresh();
            }
            File.Delete(tmp);
        }
    }
    
}
