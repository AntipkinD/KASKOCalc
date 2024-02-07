using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KASKOCalc
{

    public partial class KASKOCalc : Form
    {
        public KASKOCalc()
        {
            InitializeComponent();
        }
        public double rslt;
        public double bt;
        public double kt;
        public double kbm;
        public double ko;
        public double kvs;
        public double km;
        public double ks;
        public string tosave;
        //Метод для расчета ОСАГО
        public static void GetResult(double bt, double kt, double kbm, double ko, double kvs, double km, double ks, TextBox xtx)
        {
            double rslt = bt * kt * kbm * ko * kvs * km * ks;
            xtx.Text = Convert.ToString(rslt);
        }
        //Кнопка для расчета ОСАГО
        public void Figureout_button_Click(object sender, EventArgs e)
        {
            if (double.TryParse(baserateComboBox.Text, out this.bt) == true & double.TryParse(agecoeffComboBox.Text, out this.kt) == true & double.TryParse(franchisecoeffComboBox.Text, out this.kbm) == true & double.TryParse(ageandexpcoeffComboBox.Text, out this.ko) == true
                & double.TryParse(installmentcoeffComboBox.Text, out this.kvs) == true & double.TryParse(theftcoeffComboBox.Text, out this.km) == true & double.TryParse(alarmcoeffComboBox.Text, out this.ks) == true)
            {
                GetResult(this.bt, this.kt, this.kbm, this.ko, this.kvs, this.km, this.ks, result);
            }
            else MessageBox.Show("Пожалуйста, введите или выберите числовые значения коэффициентов!", "Неверный ввод", MessageBoxButtons.OK);
        }
        //Метод для очистки полей
        public void Clear_button_Click(object sender, EventArgs e)
        {
            baserateComboBox.Text = "Базовый тариф (БТ)";
            agecoeffComboBox.Text = "Территориальный коэффициент (КТ)";
            franchisecoeffComboBox.Text = "Коэффициент \"бонус-малус\" (КБМ)";
            ageandexpcoeffComboBox.Text = "Коэффициент ограничения (КО)";
            installmentcoeffComboBox.Text = "Коэффициент возраста и стажа (КВС)";
            theftcoeffComboBox.Text = "Коэффициент мощности двигателя (КМ)";
            alarmcoeffComboBox.Text = "Коэффициент сезонности (КС)";
            result.Text = "Результат";
        }
        //Метод для расчета ОСАГО и сохранения результата в файл
        public void Export_button_Click(object sender, EventArgs e)
        {
            if (double.TryParse(baserateComboBox.Text, out this.bt) == true & double.TryParse(agecoeffComboBox.Text, out this.kt) == true & double.TryParse(franchisecoeffComboBox.Text, out this.kbm) == true & double.TryParse(ageandexpcoeffComboBox.Text, out this.ko) == true
                & double.TryParse(installmentcoeffComboBox.Text, out this.kvs) == true & double.TryParse(theftcoeffComboBox.Text, out this.km) == true & double.TryParse(alarmcoeffComboBox.Text, out this.ks) == true & result.Text != "Результат")
            {
                GetResult(this.bt, this.kt, this.kbm, this.ko, this.kvs, this.km, this.ks, result);
                this.tosave = $"Базовый тариф (БТ): {this.bt}" +
                $"\nТерриториальный коэффициент (КТ): {this.kt}" +
                $"\nКоэффициент \"бонус-малус\" (КБМ): {this.kbm}" +
                $"\nКоэффициент ограничения (КО): {this.ko}" +
                $"\nКоэффициент возраста и стажа (КВС): {this.kvs}" +
                $"\nКоэффициент мощности двигателя (КМ): {this.km}" +
                $"\nКоэффициент сезонности (КС): {this.ks}" +
                $"\nРезультат: {result.Text}";
                Saver saver = new Saver(this.tosave);
            }
            else MessageBox.Show("Пожалуйста, сперва введите или выберите числовые значения коэффициентов и нажмите кнопку \"Расчет\"!", "Неверный ввод", MessageBoxButtons.OK);
        }
    }
}