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
        public double baserate;
        public double agecoeff;
        public double franchisecoeff;
        public double ageandexpcoeff;
        public double installmentcoeff;
        public double theftcoeff;
        public double alarmcoeff;
        public string tosave;

        //Метод для проверки коэффициентов
        public bool IsCorrect(double baserate, double agecoeff, double franchisecoeff, double ageandexpcoeff, double installmentcoeff, double theftcoeff, double alarmcoeff)
        {
            if (baserate > 0 & agecoeff > 0 & franchisecoeff > 0 & ageandexpcoeff > 0 & installmentcoeff > 0 & theftcoeff > 0 & alarmcoeff > 0)
            {
                if (baserate <= 52000 & agecoeff <= 2 & franchisecoeff <= 5 & ageandexpcoeff <= 3 & installmentcoeff <= 3 & theftcoeff <= 2 & alarmcoeff <= 2)
                    return true;
                else
                {
                    Clear();
                    MessageBox.Show("Пожалуйста, введите или выберите числовые значения коэффициентов повторно!", "Неверный ввод", MessageBoxButtons.OK);
                    return false;
                }
            }
            return false;
        }
        //Метод для расчета КАСКО
        public static void GetResult(double baserate, double agecoeff, double franchisecoeff, double ageandexpcoeff, double installmentcoeff, double theftcoeff, double alarmcoeff, TextBox xtx)
        {
            double rslt = (baserate * agecoeff * franchisecoeff * ageandexpcoeff * installmentcoeff) + (theftcoeff * ageandexpcoeff * alarmcoeff * installmentcoeff);
            xtx.Text = Convert.ToString(rslt);
        }
        //Метод для очистки полей
        public void Clear()
        {
            baserateComboBox.Text = "";
            agecoeffComboBox.Text = "";
            franchisecoeffComboBox.Text = "";
            ageandexpcoeffComboBox.Text = "";
            installmentcoeffComboBox.Text = "";
            theftcoeffComboBox.Text = "";
            alarmcoeffComboBox.Text = "";
            result.Text = "";
        }
        //Кнопка для расчета КАСКО
        public void Figureout_button_Click(object sender, EventArgs e)
        {
            
            if (double.TryParse(baserateComboBox.Text, out this.baserate) == true & double.TryParse(agecoeffComboBox.Text, out this.agecoeff) == true & double.TryParse(franchisecoeffComboBox.Text, out this.franchisecoeff) == true & double.TryParse(ageandexpcoeffComboBox.Text, out this.ageandexpcoeff) == true
                & double.TryParse(installmentcoeffComboBox.Text, out this.installmentcoeff) == true & double.TryParse(theftcoeffComboBox.Text, out this.theftcoeff) == true & double.TryParse(alarmcoeffComboBox.Text, out this.alarmcoeff) == true)
            {
                if (IsCorrect(Convert.ToDouble(baserateComboBox.Text), Convert.ToDouble(agecoeffComboBox.Text), Convert.ToDouble(franchisecoeffComboBox.Text), Convert.ToDouble(ageandexpcoeffComboBox.Text), Convert.ToDouble(installmentcoeffComboBox.Text), Convert.ToDouble(theftcoeffComboBox.Text), Convert.ToDouble(alarmcoeffComboBox.Text))==true)
                    GetResult(this.baserate, this.agecoeff, this.franchisecoeff, this.ageandexpcoeff, this.installmentcoeff, this.theftcoeff, this.alarmcoeff, result);
            }
            else MessageBox.Show("Пожалуйста, введите или выберите числовые значения коэффициентов!", "Неверный ввод", MessageBoxButtons.OK);
        }
        //Кнопка для очистки полей
        public void Clear_button_Click(object sender, EventArgs e)
        {
            Clear();
        }
        //Кнопка для расчета КАСКО в файл
        public void Export_button_Click(object sender, EventArgs e)
        {
            if (double.TryParse(baserateComboBox.Text, out this.baserate) == true & double.TryParse(agecoeffComboBox.Text, out this.agecoeff) == true & double.TryParse(franchisecoeffComboBox.Text, out this.franchisecoeff) == true & double.TryParse(ageandexpcoeffComboBox.Text, out this.ageandexpcoeff) == true
                & double.TryParse(installmentcoeffComboBox.Text, out this.installmentcoeff) == true & double.TryParse(theftcoeffComboBox.Text, out this.theftcoeff) == true & double.TryParse(alarmcoeffComboBox.Text, out this.alarmcoeff) == true & result.Text != "Результат")
            {
                if (IsCorrect(Convert.ToDouble(baserateComboBox.Text), Convert.ToDouble(agecoeffComboBox.Text), Convert.ToDouble(franchisecoeffComboBox.Text), Convert.ToDouble(ageandexpcoeffComboBox.Text), Convert.ToDouble(installmentcoeffComboBox.Text), Convert.ToDouble(theftcoeffComboBox.Text), Convert.ToDouble(alarmcoeffComboBox.Text)) == true)
                {
                    GetResult(this.baserate, this.agecoeff, this.franchisecoeff, this.ageandexpcoeff, this.installmentcoeff, this.theftcoeff, this.alarmcoeff, result);
                    this.tosave = $"Базовый тариф (Тб): {this.baserate}" +
                    $"\nКоэффициент возраста авто (Кг): {this.agecoeff}" +
                    $"\nКоэффициент франшизы (Кф): {this.franchisecoeff}" +
                    $"\nКоэффициент возраста и стажа водителя (Кв): {this.ageandexpcoeff}" +
                    $"\nКоэффициент рассрочки (Кр): {this.installmentcoeff}" +
                    $"\nКоэффициент хищения (Кх): {this.theftcoeff}" +
                    $"\nКоэффициент охранной сигнализации (Ко): {this.alarmcoeff}" +
                    $"\nРезультат: (Тб * Кг * Кф * Кв * Кр) + (Кх * Кв * Ко * Кр) = ({this.baserate} * {this.agecoeff} * {this.franchisecoeff} * {this.ageandexpcoeff} * {this.installmentcoeff}) + ({this.theftcoeff} * {this.ageandexpcoeff} * {this.alarmcoeff} * {this.installmentcoeff}) = {result.Text}";
                    Saver saver = new Saver(this.tosave);
                }
            }
            else MessageBox.Show("Пожалуйста, сперва введите или выберите числовые значения коэффициентов", "Неверный ввод", MessageBoxButtons.OK);
        }
    }
}