using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KASKOCalc
{
    //Класс для сохранения в файл
    public class Saver
    {
        public Saver(string text)
        {
            SaveTo(text);
        }
        void SaveTo(string text)
        {
            SaveFileDialog mainsavefd = new SaveFileDialog()
            {
                FileName = "расчетосаго.txt"
            };
            if (mainsavefd.ShowDialog() == DialogResult.OK)
            {
                using (Stream mainstream = File.Open(mainsavefd.FileName, FileMode.Create))
                using (StreamWriter mainstreamwriter = new StreamWriter(mainstream))
                {
                    mainstreamwriter.Write(text);
                }
            }
        }
    }
}
