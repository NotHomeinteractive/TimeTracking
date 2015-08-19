using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;


namespace PhoneBookConfigurator
{
    public partial class Form1 : Form
    {
       
        //координаты для поля с названием 
        Point Posiciya = new Point()
        {
            X = 4,
            Y = 6
        };
        //ширина и высота столбца
        Size sizeL = new Size()
        {
            Width = 1,
            Height = 20
        };

        //загрузка таблици мз АД 
        private DataTable LoadDataAD(string _putch) 
        {
            //можно загружать информацию
            FileInfo ADfile = new FileInfo(_putch);
            //полняй путь к папке 
            string FullPatchToFile = ADfile.Directory.ToString();
            //задаем его для чтения файлика 
            DBXML MyDB = new DBXML();
            //путь к директори для чтения файла 
            MyDB.PatchDir = FullPatchToFile;
            //если данные не загружались грузим их из таблицы
            return MyDB.LoadDataTablefromXML("AD");
        }

        //проверка флажка 
        private void ChangedCheck(object sender, EventArgs e)
        {
            CheckBox check = sender as CheckBox;
            
            if (check.CheckState== CheckState.Checked)
                check.Text = "скрытое"; 
            else
                check.Text = "видимое";
          
        }
        //при смене текста будем анимировать флажок 
        private void TextChanged(object sender, EventArgs e)
        {
            TextBox ComponentChanged = sender as TextBox;
            //получаем имя поля в котором ввели текст 
            string NameControl = ComponentChanged.Name.ToString();
            //разбираем имя на составляющие 
            string[] ParsName = NameControl.Split('_');
            //находим компонент который нада включить
            Control[] FindContorol = ContentAD.Controls.Find("Visible_" + ParsName[1], false);

            //показывать или прятать флажок в зависимости от заполнености текстового поля 
            if (ComponentChanged.Text.Length > 0)
                foreach (Control F in FindContorol)
                    F.Visible = true;
            else 
                foreach (Control F in FindContorol)
                    F.Visible = false;
        }
        //сортировка столбцов из таблицы AD 
        private DataRow[] SortData(DataTable AD) 
        {
            List<string> rows = new List<string>();
            //создаем столбец для сортировки данных 
            DataColumn NameColumns = new DataColumn()
            {
                ColumnName = "NameADparam",
                DataType = System.Type.GetType("System.String")
            };
            //создаем таблицу 
            DataTable mySortAdRow = new DataTable("MySortAdParams");
            mySortAdRow.Columns.Add(NameColumns);
            //грузим список столбцов из AD
            foreach (DataColumn Col in AD.Columns) 
            {
                //создаем новый столбец
                DataRow R = mySortAdRow.NewRow();
                //задаем ему значение 
                R[0] = Col.ColumnName.ToString();
                //добавляем его в таблицу
                mySortAdRow.Rows.Add(R);
            }
            //сортируем таблицу
            string sortOrder = "NameADparam ASC";
            return mySortAdRow.Select(null, sortOrder);
        }

        //добавление данных из таблиц АД в справочник
        private void ADD_ADInfo(int WX, Panel LinkPanel) 
        {
            
            //если панел пуста то згружаем на нее данные 
            if (LinkPanel.Controls.Count == 0)
                {
                #region загружаем новые значения
                string FileConfigName = textBox1.Text;
                string FileADName = textBox2.Text;
                //проверяем сущестует ли файл по указанному в настройках пути 
                if (File.Exists(FileADName))
                {
                    Posiciya = new Point() 
                    { 
                        X = 4, 
                        Y = 6 
                    };
                    Point PosiciyaText = new Point() 
                    { 
                        X = sizeL.Width+10,
                        Y = 6
                    };
                    Point PosiciyaCheck = new Point() 
                    {
                        X = (sizeL.Width + 10)*2,
                        Y = 6
                    };
                     //смещение по Y
                    int DY = 25;
                    sizeL.Width = WX;
                    //загружаем данные из АД 
                    DataTable ADTable = LoadDataAD(FileADName);

                    DataRow[] ADParam  =  SortData(ADTable);

                     //перебираем список столбцоа таблицы из АД 
                    foreach (DataRow Col in ADParam)
                    { 
                       //создаем поле с надписями 
                       TextBox ADtext=new TextBox()
                       {
                           Name = "Name_" + Col[0].ToString(),
                           Text = Col[0].ToString(),
                           ReadOnly=true,
                           Location=Posiciya,
                           Size = sizeL
                       };

                        //текстовое поле для заполнения 
                        TextBox PhoneValue = new TextBox()
                        {
                            Name = "Phone_" + Col[0].ToString(),
                            Text="",
                            Location = PosiciyaText,
                            Size = sizeL
                        };
                        //закрепляем событие за текстовым полем 
                        PhoneValue.TextChanged += TextChanged;
                        //PhoneValue.LostFocus += TextChanged;
                        //отображение поля на форме 
                        CheckBox VisibleCheck = new CheckBox()
                        {
                            Name = "Visible_" + Col[0].ToString(),
                             Location=PosiciyaCheck,
                             Checked=false,
                             Text = "видимое"
                        };
                        VisibleCheck.CheckedChanged += ChangedCheck;

                        PosiciyaCheck.Y += DY;
                        PosiciyaText.Y += DY;
                        Posiciya.Y += DY;
                        //добавляем столбец на экрн
                       LinkPanel.Controls.Add(ADtext);
                       LinkPanel.Controls.Add(PhoneValue);
                       LinkPanel.Controls.Add(VisibleCheck);
                       VisibleCheck.Visible = false;
               
                }
                }
                else
                {
                    MessageBox.Show("Файл данных AD.xml не найден \n проверьте путь в настройках");
                    Panelss.SelectedIndex = 3;
                }
                #endregion
                }

        }
        
        private void ADDHead(string[] Head,int WX, Panel LinkPanel ) 
        {
            //если панел пуста то згружаем на нее данные 
            if (LinkPanel.Controls.Count == 0) 
            {
                sizeL.Width = WX;
                    
               foreach(string txt in Head)
               {
                   TextBox _LABEL = new TextBox()
                   {
                       Text = txt,
                       TextAlign = HorizontalAlignment.Center,
                       Size = sizeL,
                       ReadOnly = true,
                       Location = Posiciya
                   };
                   LinkPanel.Controls.Add(_LABEL);
                   //смещаем позицию на 10 и ширину надписи
                   Posiciya.X += (sizeL.Width + 10);
               }
            }
        }
      
        public Form1()
        {
            InitializeComponent();
        }

        private void Panelss_Selected(object sender, TabControlEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "config.xml";

           openFileDialog1.ShowDialog();

            string FileName=openFileDialog1.FileName;
            if (File.Exists(FileName)) 
                textBox1.Text = FileName;
            else 
                textBox1.Text = "Файл не найден ";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "AD.xml";

            openFileDialog1.ShowDialog();

            string FileName = openFileDialog1.FileName;
            if (File.Exists(FileName))
                textBox2.Text = FileName;
            else
                textBox2.Text = "Файл не найден ";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Panelss.SelectedIndex = 3;

            if (File.Exists("config.xml")) textBox1.Text = "config.xml"; else textBox1.Text = "Файл config.xml не найден";
                if (File.Exists("AD.xml")) textBox2.Text = "AD.xml"; else textBox2.Text = "Файл AD.xml не найден";
        }

        private void Panelss_SelectedIndexChanged(object sender, EventArgs e)
        {
            int IndexPanel = Panelss.SelectedIndex;

            switch (IndexPanel)
            {
                    case 0:
                        //список наименования столбцов таблицы
                        string[] Headers= 
                        {
                            "Название поля в АД",
                            "Название поля в книге",
                            "Видимость поля в книге"
                        };
                        //расчитываем длинну 1 столбца в таблице
                        int LenghText = this.HeadPanel1.Width / Headers.Length - (Headers.Length * Headers.Length);
                        //создаем заголовок для блока
                        ADDHead(Headers,LenghText , HeadPanel1);
                        //загружаем конетнт в панель 
                        ADD_ADInfo(LenghText, ContentAD);
                        break;
                    case 1: 
                        break;
                    case 2: 
                        break;
                    case 3: 
                        break;
                    case 4: 
                        break;
            }
        }

        private void Panelss_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

      
      

       
    }
}
