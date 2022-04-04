using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace WindowsFormsApplication1
{

    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            TopMost = true;
            label23.Text = ("Timp ramas: ");
            pictureBox11.Visible = true;
            pictureBox10.Visible = false;
            groupBox1.Visible = false;
            button6.Visible = false;
            groupBox8.Visible = false;
            button15.Visible = false;
            label23.Font = new Font("Century Gothic", 12, FontStyle.Bold);
            
          /*  this.AutoScroll = true;
            this.AutoSize = true;
            this.Controls.Add(new Panel() { Width = 2300, Height = 2000 });
            //this one will only set window size to size of screen
            this.ClientSize = new System.Drawing.Size(2300, 2000);
            *///adauga scroll baruri pt ecranuri cu rezolutie mica
           
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;// ascunde tab controlul
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                WindowState = FormWindowState.Normal;
                TopMost = false;
            }

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet.Punctaj_utilizator' table. You can move, or remove it, as needed.
            this.punctaj_utilizatorTableAdapter.Fill(this.database1DataSet.Punctaj_utilizator);
            // TODO: This line of code loads data into the 'database1DataSet.Intrebari' table. You can move, or remove it, as needed.
            this.intrebariTableAdapter.Fill(this.database1DataSet.Intrebari);

            // TODO: This line of code loads data into the 'database1DataSet.Clienti' table. You can move, or remove it, as needed.
            this.clientiTableAdapter.Fill(this.database1DataSet.Clienti);

            tabControl1.SelectedIndex = 0;



        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            textBox1.Text = "";
            textBox2.Text = "";
        }

        /*   private void button3_Click(object sender, EventArgs e)
           {

               string nume = textBox3.Text;
               string prenume = textBox4.Text;
               string email = textBox5.Text;
               string username = textBox6.Text;
               string parola = textBox7.Text;
               string intrebare = textBox8.Text;
               this.clientiTableAdapter.Fill(database1DataSet.Clienti);
               DataTable dt = database1DataSet.Clienti;
               int i, okemail = 0, okusername = 0;
               for (i = 0; i < dt.Rows.Count; i++)
               {

                   if (dt.Rows[i]["Username"].ToString().CompareTo(username) == 0)
                   {
                       MessageBox.Show("Acest username este deja utilizat, incearca altul.");
                       textBox6.Text = "";
                       okusername = 1;
                   }
                   if (dt.Rows[i]["E-mail"].ToString().CompareTo(email) == 0)
                   {
                       MessageBox.Show("Acest e-mail a fost deja folosit pentru creeare altui cont, foloseste altul.");
                       textBox5.Text = "";
                       okemail = 1;
                   }
               }
               if (textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "")
               {
                   this.clientiTableAdapter.InsertQuery_inregistrari(nume, prenume, email, username, parola, nr_examene_admise, nr_examene_picate, nr_examene_admise, nr_examene_picate, intrebare);

                   this.clientiTableAdapter.Update(this.database1DataSet.Clienti);
                   this.clientiTableAdapter.Fill(this.database1DataSet.Clienti);
                   MessageBox.Show("Te-ai inregistrat cu succes! Acum logheaza-te.");
                   textBox3.Text = "";
                   textBox4.Text = "";
                   textBox5.Text = "";
                   textBox6.Text = "";
                   textBox7.Text = "";
                   textBox8.Text = "";
                   tabControl1.SelectedIndex = 0;


               }
               if (!(textBox3.Text.Trim() != "" && textBox4.Text.Trim() != "" && textBox5.Text.Trim() != "" && textBox6.Text.Trim() != "" && textBox7.Text.Trim() != ""))
                   if (okemail == 0 && okusername == 0)
                       MessageBox.Show("Completeaza toate datele personale!");
                   else { okemail = 0; okusername = 0; }
               //copiaza din bin debug database1.sdf in windowsformapplication1 (folderul principal)

           }*/

        int indice_logare;
        private void button2_Click(object sender, EventArgs e)
        {

            this.clientiTableAdapter.Fill(database1DataSet.Clienti);
            DataTable dt = database1DataSet.Clienti;
            string s1 = textBox1.Text;
            string s2 = textBox2.Text;

            int ok1 = -1, ok2 = -1;
            if (s1 == "")
                MessageBox.Show("Va rog introduceti username-ul sau email-ul.");
            if (s2 == "")
                MessageBox.Show("Va rog introduceti parola.");
            if (s1 != "" && s2 != "")
            {
                int i = 0;
                while (i < dt.Rows.Count && ok1 != 1 && ok1 != 1)
                {
                    if (dt.Rows[i]["E-mail"].ToString().CompareTo(s1) == 0 || dt.Rows[i]["Username"].ToString().CompareTo(s1) == 0)
                        ok1 = 1;
                    else ok1 = 0;

                    if (dt.Rows[i]["Parola"].ToString().CompareTo(s2) == 0)
                        ok2 = 1;
                    else ok2 = 0;
                    i++;
                }

                if (ok1 == 1 && ok2 == 1)
                {
                    tabControl1.SelectedIndex = 2;
                    
                    textBox1.Text = "";
                    textBox2.Text = "";
                    indice_logare = i;
                    DataTable df = this.database1DataSet.Punctaj_utilizator;
                    int j,ok=1;
                    for (j = 0; j < df.Rows.Count; j++)
                        if (int.Parse(df.Rows[j]["idc"].ToString()) == indice_logare)
                        {ok = 0; break;}
                

                    if (ok == 1)
                    {
                        this.punctaj_utilizatorTableAdapter.InsertQuery_informatii(0, 0, indice_logare);
                        this.punctaj_utilizatorTableAdapter.Update(database1DataSet.Punctaj_utilizator);
                        this.punctaj_utilizatorTableAdapter.Fill(database1DataSet.Punctaj_utilizator);
                    }
                    if(ok==0)
                        for (i = 0; i < df.Rows.Count; i++)
                            if (int.Parse(df.Rows[i]["idc"].ToString()) == indice_logare)
                            {
                                label3.Text = "Punctajul maxim obtinut in sesiunea curenta la simularile examenului auto este: " + df.Rows[i]["Punctaj_maxim"].ToString();
                                label4.Text = "Punctajul minim obtinut in sesiunea curenta la simularile examenului auto este: " + df.Rows[i]["Punctaj_minim"].ToString();
                            }

                    label38.Text ="Bun venit, "+(dt.Rows[indice_logare-1]["Prenume"]).ToString()+"!";
                     
                    
                }
                if (ok1 == 0 || ok2 == 0)
                    MessageBox.Show("Username-ul/E-mail-ul si/sau parola sunt incorecte! Nu v-ati putut loga.");

            }




        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
        }


      
        public static List<T> Randomize<T>(List<T> list)
        {
            List<T> lista_amestecata = new List<T>();
            Random rnd = new Random();
            while (list.Count > 0)
            {
                int i = rnd.Next(0, list.Count); //se alege un item random
                lista_amestecata.Add(list[i]); //se adauga itemul random in noua lista amestecata
                list.RemoveAt(i);//se elimina din lista originala
            }
            return lista_amestecata;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button15.Visible = false;
            groupBox8.Visible = false;

            if (button6.Visible == false)
            {
                groupBox1.Visible = true;
                button6.Visible = true;
            }
            else if (button6.Visible == true)
            {
                groupBox1.Visible = false;
                button6.Visible = false;
            }
            timer1.Tick -= new EventHandler(timer1_Tick);

        }

        int indice;
        int ok_a, ok_b, ok_c;
        int nr_rasp_corecte, nr_rasp_gresite;
        int nr_rasp_corecte_totale = 0, nr_rasp_gresite_totale = 0;
        List<int> lista_intrebari = new List<int>();
        int ok1, ok2, ok3;

        private void timer1_Tick(object sender, EventArgs e)
        {
            counter--;
            if (counter == 0)
                timer1.Stop();

           
            label23.Text = ("Timp ramas: " + counter / 60 + " minute si " + counter % 60 + " secunde").ToString();


        }

        int counter = 0;
        private void button6_Click(object sender, EventArgs e)
        {
          

        }
        int nr_examene_admise = 0, nr_examene_picate = 0;
        private void button7_Click(object sender, EventArgs e)
        {

            DataTable dt = this.database1DataSet.Intrebari;
            this.intrebariTableAdapter.Fill(this.database1DataSet.Intrebari);
            label16.BackColor = Color.Transparent;
            label16.ForeColor = Color.White;
            label17.BackColor = Color.Transparent;
            label17.ForeColor = Color.White;
            label18.BackColor = Color.Transparent;
            label18.ForeColor = Color.White;
            button11.BackColor = Color.White;
            button12.BackColor = Color.White;
            button13.BackColor = Color.White;



            if (validare(counter) == 1)
            {
                if (checkBox1.Checked != false || checkBox2.Checked != false || checkBox3.Checked != false)
                {
                    if (checkBox1.Checked == true)
                        ok_a = 1;
                    else ok_a = 0;

                    if (checkBox2.Checked == true)
                        ok_b = 1;
                    else ok_b = 0;

                    if (checkBox3.Checked == true)
                        ok_c = 1;
                    else ok_c = 0;
                    if (ok_a == int.Parse(dt.Rows[lista_intrebari[indice] - 1]["a"].ToString()) && ok_b == int.Parse(dt.Rows[lista_intrebari[indice] - 1]["b"].ToString()) && ok_c == int.Parse(dt.Rows[lista_intrebari[indice] - 1]["c"].ToString()))
                    { nr_rasp_corecte++; nr_rasp_corecte_totale++; }
                    else
                    {
                        nr_rasp_gresite++;
                        if (nr_rasp_gresite == 1 && dt.Rows[lista_intrebari[indice] - 1]["poza"].ToString().Length != 0)
                        {
                            string path = Directory.GetCurrentDirectory().Remove(Directory.GetCurrentDirectory().Length - 9);
                            Bitmap image = new Bitmap(path + "\\pozele\\" + dt.Rows[lista_intrebari[indice] - 1]["poza"].ToString());
                            pictureBox2.Visible = true;
                            pictureBox2.Image = (Image)image;
                            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                        
                        

                        if (nr_rasp_gresite == 2 && dt.Rows[lista_intrebari[indice] - 1]["poza"].ToString().Length != 0)
                        {
                            string path = Directory.GetCurrentDirectory().Remove(Directory.GetCurrentDirectory().Length - 9);
                            Bitmap image = new Bitmap(path + "\\pozele\\" + dt.Rows[lista_intrebari[indice] - 1]["poza"].ToString());
                            pictureBox3.Visible = true;
                            pictureBox3.Image = (Image)image;
                            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;


                        }
                    
                        

                        if (nr_rasp_gresite == 3 && dt.Rows[lista_intrebari[indice] - 1]["poza"].ToString().Length != 0)
                        {
                            string path = Directory.GetCurrentDirectory().Remove(Directory.GetCurrentDirectory().Length - 9);
                            Bitmap image = new Bitmap(path + "\\pozele\\" + dt.Rows[lista_intrebari[indice] - 1]["poza"].ToString());
                            pictureBox4.Visible = true;
                            pictureBox4.Image = (Image)image;
                            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;

                        }
                     

                        if (nr_rasp_gresite == 4 && dt.Rows[lista_intrebari[indice] - 1]["poza"].ToString().Length != 0)
                        {
                            string path = Directory.GetCurrentDirectory().Remove(Directory.GetCurrentDirectory().Length - 9);
                            Bitmap image = new Bitmap(path + "\\pozele\\" + dt.Rows[lista_intrebari[indice] - 1]["poza"].ToString());
                            pictureBox5.Visible = true;
                            pictureBox5.Image = (Image)image;
                            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;

                        }
                  



                        nr_rasp_gresite_totale++;
                        listBox1.Items.Add("INTREBAREA " + nr_rasp_gresite);
                        listBox1.Items.Add("\n");
                        listBox1.Items.Add(dt.Rows[lista_intrebari[indice] - 1]["Intrebare"].ToString());
                        listBox1.Items.Add(dt.Rows[lista_intrebari[indice] - 1]["Var_a"].ToString());
                        listBox1.Items.Add(dt.Rows[lista_intrebari[indice] - 1]["Var_b"].ToString());
                        listBox1.Items.Add(dt.Rows[lista_intrebari[indice] - 1]["Var_c"].ToString());
                        listBox1.Items.Add("\n");
                        listBox1.Items.Add("RASPUNSURILE CORECTE AU FOST:");
                        if (int.Parse(dt.Rows[lista_intrebari[indice] - 1]["a"].ToString()) == 1)
                            listBox1.Items.Add(dt.Rows[lista_intrebari[indice] - 1]["Var_a"].ToString());
                        if (int.Parse(dt.Rows[lista_intrebari[indice] - 1]["b"].ToString()) == 1)
                            listBox1.Items.Add(dt.Rows[lista_intrebari[indice] - 1]["Var_b"].ToString());
                        if (int.Parse(dt.Rows[lista_intrebari[indice] - 1]["c"].ToString()) == 1)
                            listBox1.Items.Add(dt.Rows[lista_intrebari[indice] - 1]["Var_c"].ToString());
                        listBox1.Items.Add("\n");
                        listBox1.Items.Add("RASPUNSURILE SELECTATE DE DUMNEVOASTRA AU FOST:");
                        if (ok_a == 1)
                            listBox1.Items.Add(dt.Rows[lista_intrebari[indice] - 1]["Var_a"].ToString());
                        if (ok_b == 1)
                            listBox1.Items.Add(dt.Rows[lista_intrebari[indice] - 1]["Var_b"].ToString());
                        if (ok_c == 1)
                            listBox1.Items.Add(dt.Rows[lista_intrebari[indice] - 1]["Var_c"].ToString());
                        listBox1.Items.Add("\n");


                    }
                    if (nr_rasp_gresite <= 4)
                    {
                        indice++;



                        ok1 = 0;
                        ok2 = 0;
                        ok3 = 0;
                        label15.Text = dt.Rows[lista_intrebari[indice] - 1]["Intrebare"].ToString().Trim();
                        label16.Text = dt.Rows[lista_intrebari[indice] - 1]["Var_a"].ToString().Trim();
                        label17.Text = dt.Rows[lista_intrebari[indice] - 1]["Var_b"].ToString().Trim();
                        label18.Text = dt.Rows[lista_intrebari[indice] - 1]["Var_c"].ToString().Trim();
                        if (dt.Rows[lista_intrebari[indice] - 1]["poza"].ToString().Length != 0)
                        {
                            string path = Directory.GetCurrentDirectory().Remove(Directory.GetCurrentDirectory().Length - 9);
                            Bitmap image = new Bitmap(path + "\\pozele\\" + dt.Rows[lista_intrebari[indice] - 1]["poza"].ToString());
                            pictureBox1.Visible = true;
                            pictureBox1.Image = (Image)image;
                        }
                        else pictureBox1.Image = null;
                        checkBox1.Checked = false;
                        checkBox2.Checked = false;
                        checkBox3.Checked = false;
                    }
                    else
                    {
                        if (nr_rasp_gresite == 5 && dt.Rows[lista_intrebari[indice] - 1]["poza"].ToString().Length != 0)
                        {
                            string path = Directory.GetCurrentDirectory().Remove(Directory.GetCurrentDirectory().Length - 9);
                            Bitmap image = new Bitmap(path + "\\pozele\\" + dt.Rows[lista_intrebari[indice] - 1]["poza"].ToString());
                            pictureBox6.Visible = true;
                            pictureBox6.Image = (Image)image;
                            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;

                        }
                      
                        MessageBox.Show("Testul a luat sfârşit. Aţi fost declarat RESPINS la examenul de teorie.");
                        tabControl1.SelectedIndex = 6;
                        nr_examene_picate++;

                    }
                    label20.Text = 26 - indice + " " + "Intrebari ramase";
                    label21.Text = nr_rasp_corecte + " Intrebari corecte";
                    label22.Text = nr_rasp_gresite + " Intrebari gresite";
                    if (indice == 26)
                    {
                        MessageBox.Show("Testul a luat sfârşit. Aţi fost declarat ADMIS la examenul de teorie.");
                        nr_examene_admise++;
                        if (nr_rasp_gresite == 0)
                            tabControl1.SelectedIndex = 2;
                        else tabControl1.SelectedIndex = 6;
                    }
                }
                else MessageBox.Show("Trebuie selectata cel putin o varianta de raspuns.");
            }
            else if (nr_rasp_corecte >= 22)
                MessageBox.Show("Testul a luat sfarsit. Ati fost declarat admis.");
            else MessageBox.Show("Testul a luat sfarsit. Ati fost declarat respins.");

        }

        private void button8_Click(object sender, EventArgs e)
        {
            DataTable dt = database1DataSet.Punctaj_utilizator;
            int i;
            for (i = 0; i < dt.Rows.Count; i++)
                if (int.Parse(dt.Rows[i]["idc"].ToString()) == indice_logare)
                    break;

         
            if (int.Parse(dt.Rows[i]["Punctaj_maxim"].ToString()) > nr_rasp_corecte)
            {
                this.punctaj_utilizatorTableAdapter.UpdateQuery_punctaje(int.Parse(dt.Rows[i]["Punctaj_maxim"].ToString()), nr_rasp_corecte, indice_logare); 
                this.punctaj_utilizatorTableAdapter.Update(database1DataSet.Punctaj_utilizator);
                this.punctaj_utilizatorTableAdapter.Fill(database1DataSet.Punctaj_utilizator);
            }

            if (int.Parse(dt.Rows[i ]["Punctaj_minim"].ToString()) < nr_rasp_corecte)
            {
                this.punctaj_utilizatorTableAdapter.UpdateQuery_punctaje(nr_rasp_corecte, int.Parse(dt.Rows[i]["Punctaj_minim"].ToString()), indice_logare);
                this.punctaj_utilizatorTableAdapter.Update(database1DataSet.Punctaj_utilizator);
                this.punctaj_utilizatorTableAdapter.Fill(database1DataSet.Punctaj_utilizator);
            }

            tabControl1.SelectedIndex = 2;
            listBox1.Items.Clear();
            this.clientiTableAdapter.Fill(this.database1DataSet.Clienti);
            dt = database1DataSet.Clienti;
            this.clientiTableAdapter.UpdateQuery_statistici(int.Parse(dt.Rows[indice_logare - 1]["numar_intrebari_corecte"].ToString()) + nr_rasp_corecte_totale, int.Parse(dt.Rows[indice_logare - 1]["numar_intrebari_gresite"].ToString()) + nr_rasp_gresite_totale, int.Parse(dt.Rows[indice_logare - 1]["numar_teste_admise"].ToString()) + nr_examene_admise, int.Parse(dt.Rows[indice_logare - 1]["numar_teste_respinse"].ToString()) + nr_examene_picate, indice_logare);
            this.clientiTableAdapter.Fill(this.database1DataSet.Clienti);
            pictureBox1.Image = null;
            pictureBox1.Update();

            string path = Directory.GetCurrentDirectory().Remove(Directory.GetCurrentDirectory().Length - 9);
            Bitmap image = new Bitmap(path + "\\pozele\\indisponibil.png");
            pictureBox2.Visible = true;
            pictureBox2.Image = (Image)image;
            pictureBox2.Update();
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.Image = (Image)image;
            pictureBox3.Update();
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.Image = (Image)image;
            pictureBox4.Update();
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.Image = (Image)image;
            pictureBox5.Update();
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.Image= (Image)image;
            pictureBox6.Update();
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;


            nr_rasp_corecte = 0;
            nr_rasp_gresite = 0;
            DataTable df = database1DataSet.Punctaj_utilizator;
            for (i = 0; i < df.Rows.Count; i++)
                if (int.Parse(df.Rows[i]["idc"].ToString()) == indice_logare)
                {
                    label3.Text =  "Punctajul maxim obtinut in sesiunea curenta la simularile examenului auto este: "+df.Rows[i]["Punctaj_maxim"].ToString();
                    label4.Text =  "Punctajul minim obtinut in sesiunea curenta la simularile examenului auto este: " + df.Rows[i]["Punctaj_minim"].ToString();
                }





        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.clientiTableAdapter.Fill(this.database1DataSet.Clienti);
            DataTable dt = database1DataSet.Clienti;
            tabControl1.SelectedIndex = 7;
            label26.Text = "Numarul total al intrebarilor la care ai raspuns corect este: " + dt.Rows[indice_logare - 1]["numar_intrebari_corecte"];
            label27.Text = "Numarul total al intrebarilor la care ai raspuns gresit este: " + dt.Rows[indice_logare - 1]["numar_intrebari_gresite"];
            label28.Text = "Numarul total al testelor la care ai fost admis este: " + dt.Rows[indice_logare - 1]["numar_teste_admise"];
            label29.Text = "Numarul total al testelor la care ai fost respins este: " + dt.Rows[indice_logare - 1]["numar_teste_respinse"];
            double rata = 0;
            if (int.Parse(dt.Rows[indice_logare - 1]["numar_teste_admise"].ToString()) == 0 && int.Parse(dt.Rows[indice_logare - 1]["numar_teste_respinse"].ToString()) == 0)
            { }
            else rata = int.Parse(dt.Rows[indice_logare - 1]["numar_teste_admise"].ToString()) / (int.Parse(dt.Rows[indice_logare - 1]["numar_teste_admise"].ToString()) + int.Parse(dt.Rows[indice_logare - 1]["numar_teste_respinse"].ToString())) * 100.0;
            if (int.Parse(dt.Rows[indice_logare - 1]["numar_teste_admise"].ToString()) == 0 && int.Parse(dt.Rows[indice_logare - 1]["numar_teste_respinse"].ToString()) == 0)
                label30.Text = "Nu exista inca rata de promovabilitate.";
            else label30.Text = "Rata de promovabilitate este: " + rata + "%";
            label31.Text = "Nume: " + dt.Rows[indice_logare - 1]["Nume"];
            label32.Text = "Prenume: " + dt.Rows[indice_logare - 1]["Prenume"];
            label33.Text = "E-mail: " + dt.Rows[indice_logare - 1]["E-mail"];
            label34.Text = "Username: " + dt.Rows[indice_logare - 1]["Username"];
            label35.Text = "Parola: " + dt.Rows[indice_logare - 1]["Parola"];
            label47.Text = "Raspunsul la intrebarea de siguranta: " + dt.Rows[indice_logare - 1]["Intrebare_parola"];

        }

        static int validare(int counter)
        {
            if (counter == 0)
                return 0;
            return 1;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (validare(counter) == 1)
            {
                if (nu_mai_pot == 1)
                {
                    ok1++;


                    if (ok1 % 2 == 1)
                    {
                        label16.BackColor = Color.Gold;
                        label16.ForeColor = Color.Black;
                        checkBox1.Checked = true;
                        button11.BackColor = Color.Gold;
                    }
                    if (ok1 % 2 == 0)
                    {
                        checkBox1.Checked = false;
                        label16.BackColor = Color.Transparent;
                        label16.ForeColor = Color.White;
                        button11.BackColor = Color.White;
                    }
                }
            }
            else if (nr_rasp_corecte >= 22)
            {
                MessageBox.Show("Testul a luat sfarsit. Ati fost declarat admis.");
                if (nr_rasp_corecte == 26) tabControl1.SelectedIndex = 2; else tabControl1.SelectedIndex = 6;
            }
            else { MessageBox.Show("Testul a luat sfarsit. Ati fost declarat respins."); if (nr_rasp_gresite == 0) tabControl1.SelectedIndex = 2; else tabControl1.SelectedIndex = 6; }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (validare(counter) == 1)
            {
                if (nu_mai_pot == 1)
                {
                    ok2++;


                    if (ok2 % 2 == 1)
                    {
                        label17.BackColor = Color.Gold;
                        label17.ForeColor = Color.Black;
                        checkBox2.Checked = true;
                        button12.BackColor = Color.Gold;
                    }
                    if (ok2 % 2 == 0)
                    {
                        checkBox2.Checked = false;
                        label17.BackColor = Color.Transparent;
                        label17.ForeColor = Color.White;
                        button12.BackColor = Color.White;
                    }
                }

            }
            else if (nr_rasp_corecte >= 22)
            {
                MessageBox.Show("Testul a luat sfarsit. Ati fost declarat admis.");
                if (nr_rasp_corecte == 26) tabControl1.SelectedIndex = 2; else tabControl1.SelectedIndex = 6;
            }
            else { MessageBox.Show("Testul a luat sfarsit. Ati fost declarat respins."); if (nr_rasp_gresite == 0) tabControl1.SelectedIndex = 2; else tabControl1.SelectedIndex = 6; }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (validare(counter) == 1)
            {
                if (nu_mai_pot == 1)
                {
                    ok3++;


                    if (ok3 % 2 == 1)
                    {
                        label18.BackColor = Color.Gold;
                        label18.ForeColor = Color.Black;
                        checkBox3.Checked = true;
                        button13.BackColor = Color.Gold;
                    }
                    if (ok3 % 2 == 0)
                    {
                        checkBox3.Checked = false;
                        label18.BackColor = Color.Transparent;
                        label18.ForeColor = Color.White;
                        button13.BackColor = Color.White;
                    }
                }
            }
            else if (nr_rasp_corecte >= 22)
            {
                MessageBox.Show("Testul a luat sfarsit. Ati fost declarat admis.");
                if (nr_rasp_corecte == 26) tabControl1.SelectedIndex = 2; else tabControl1.SelectedIndex = 6;
            }
            else { MessageBox.Show("Testul a luat sfarsit. Ati fost declarat respins."); if (nr_rasp_gresite == 0) tabControl1.SelectedIndex = 2; else tabControl1.SelectedIndex = 6; }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            button6.Visible = false;
            groupBox1.Visible = false;
            if (button15.Visible == false)
            {
                button15.Visible = true;
                groupBox8.Visible = true;
            }
            else if (button15.Visible == true)
            {
                button15.Visible = false;
                groupBox8.Visible = false;
            }

        }
        int indice_mediu_de_invatare = 0;

        private void button15_Click(object sender, EventArgs e)
        {
           

        }

        private void button16_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }
        int nu_mai_pot = 1;
        private void button17_Click(object sender, EventArgs e)
        {

            this.intrebariTableAdapter.Fill(this.database1DataSet.Intrebari);
            DataTable dt = this.database1DataSet.Intrebari;




            ok_a = 0;
            ok_b = 0;
            ok_c = 0;
            ok1 = 0;
            ok2 = 0;
            ok3 = 0;

            label16.BackColor = Color.Transparent;
            label16.ForeColor = Color.White;
            label17.BackColor = Color.Transparent;
            label17.ForeColor = Color.White;
            label18.BackColor = Color.Transparent;
            label18.ForeColor = Color.White;
            button11.BackColor = Color.White;
            button12.BackColor = Color.White;
            button13.BackColor = Color.White;




            if (checkBox1.Checked != false || checkBox2.Checked != false || checkBox3.Checked != false)
            {
                if (checkBox1.Checked == true)
                    ok_a = 1;
                else ok_a = 0;

                if (checkBox2.Checked == true)
                    ok_b = 1;
                else ok_b = 0;

                if (checkBox3.Checked == true)
                    ok_c = 1;
                else ok_c = 0;
                if (ok_a == int.Parse(dt.Rows[indice_mediu_de_invatare]["a"].ToString()) && ok_b == int.Parse(dt.Rows[indice_mediu_de_invatare]["b"].ToString()) && ok_c == int.Parse(dt.Rows[indice_mediu_de_invatare]["c"].ToString()))
                    nr_rasp_corecte++;
                else nr_rasp_gresite++;
                nu_mai_pot = 0;
                if (ok_a == 1)
                    label41.Visible = true;
                if (ok_b == 1)
                    label42.Visible = true;
                if (ok_c == 1)
                    label43.Visible = true;
                if (int.Parse(dt.Rows[indice_mediu_de_invatare]["a"].ToString()) == 1)
                {
                    label16.BackColor = Color.Green;
                    button11.BackColor = Color.Green;
                }
                else
                {
                    label16.BackColor = Color.Red;
                    button11.BackColor = Color.Red;
                }

                if (int.Parse(dt.Rows[indice_mediu_de_invatare]["b"].ToString()) == 1)
                {
                    label17.BackColor = Color.Green;
                    button12.BackColor = Color.Green;
                }
                else
                {
                    label17.BackColor = Color.Red;
                    button12.BackColor = Color.Red;
                }

                if (int.Parse(dt.Rows[indice_mediu_de_invatare]["c"].ToString()) == 1)
                {
                    label18.BackColor = Color.Green;
                    button13.BackColor = Color.Green;
                }
                else
                {
                    label18.BackColor = Color.Red;
                    button13.BackColor = Color.Red;
                }

                label21.Text = nr_rasp_corecte + " Intrebari exacte";
                label22.Text = nr_rasp_gresite + " Intrebari gresite";
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                button17.Visible = false;
                //   indice_mediu_de_invatare++;
                ok1 = 0;
                ok2 = 0;
                ok3 = 0;
                /*    if (indice_mediu_de_invatare < dt.Rows.Count)
                    {
                        label15.Text = dt.Rows[indice_mediu_de_invatare]["Intrebare"].ToString().Trim();
                        label16.Text = dt.Rows[indice_mediu_de_invatare]["Var_a"].ToString().Trim();
                        label17.Text = dt.Rows[indice_mediu_de_invatare]["Var_b"].ToString().Trim();
                        label18.Text = dt.Rows[indice_mediu_de_invatare]["Var_c"].ToString().Trim();
                    }*/

                /*if(indice_mediu_de_invatare==dt.Rows.Count)
                {
                    label15.Text = "Nu mai exista intreabari.";
                    label16.Text = "A.";
                    label17.Text = "B.";
                    label18.Text = "C.";
                }*/

            }
            else { MessageBox.Show("Trebuie selectata cel putin o varianta de raspuns."); }





        }

        private void button18_Click(object sender, EventArgs e)
        {
            this.intrebariTableAdapter.Fill(this.database1DataSet.Intrebari);
            DataTable dt = this.database1DataSet.Intrebari;
            if (indice_mediu_de_invatare - 1 < 0)
                MessageBox.Show("Nu exita o intrebare anterioara.");
            else
            {
                indice_mediu_de_invatare--;
                if (dt.Rows[indice_mediu_de_invatare]["poza"].ToString().Length != 0)
                {
                    string path = Directory.GetCurrentDirectory().Remove(Directory.GetCurrentDirectory().Length - 9);
                    Bitmap image = new Bitmap(path + "\\pozele\\" + dt.Rows[indice_mediu_de_invatare]["poza"].ToString());
                    pictureBox1.Visible = true;
                    pictureBox1.Image = (Image)image;
                }
                else pictureBox1.Visible = false;

                label41.Visible = false;
                label42.Visible = false;
                label43.Visible = false;
                nu_mai_pot = 1;

                label20.Text = "Intrebarea nr." + (indice_mediu_de_invatare + 1);
                label15.Text = dt.Rows[indice_mediu_de_invatare]["Intrebare"].ToString().Trim();
                label16.Text = dt.Rows[indice_mediu_de_invatare]["Var_a"].ToString().Trim();
                label17.Text = dt.Rows[indice_mediu_de_invatare]["Var_b"].ToString().Trim();
                label18.Text = dt.Rows[indice_mediu_de_invatare]["Var_c"].ToString().Trim();
                ok_a = 0;
                ok_b = 0;
                ok_c = 0;
                ok1 = 0;
                ok2 = 0;
                ok3 = 0;
                button17.Visible = true;
                label16.BackColor = Color.Transparent;
                label16.ForeColor = Color.White;
                label17.BackColor = Color.Transparent;
                label17.ForeColor = Color.White;
                label18.BackColor = Color.Transparent;
                label18.ForeColor = Color.White;
                button11.BackColor = Color.White;
                button12.BackColor = Color.White;
                button13.BackColor = Color.White;
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            this.intrebariTableAdapter.Fill(this.database1DataSet.Intrebari);
            DataTable dt = this.database1DataSet.Intrebari;

            if (indice_mediu_de_invatare + 1 >= dt.Rows.Count)
            {
                DialogResult dialogresult = MessageBox.Show("   Intrebarile din mediul de invatare s-au terminat.\n                   Doresti sa te intorci la meniu?", "", MessageBoxButtons.YesNo);
                if (dialogresult == DialogResult.Yes)
                { tabControl1.SelectedIndex = 2; indice_mediu_de_invatare = 0; }
            }

            else
            {
                indice_mediu_de_invatare++;
                if (dt.Rows[indice_mediu_de_invatare]["poza"].ToString().Length != 0)
                {
                    string path = Directory.GetCurrentDirectory().Remove(Directory.GetCurrentDirectory().Length - 9);
                    Bitmap image = new Bitmap(path + "\\pozele\\" + dt.Rows[indice_mediu_de_invatare]["poza"].ToString());
                    pictureBox1.Visible = true;
                    pictureBox1.Image = (Image)image;
                }
                else pictureBox1.Visible = false;

                label41.Visible = false;
                label42.Visible = false;
                label43.Visible = false;
                nu_mai_pot = 1;
                label20.Text = "Intrebarea nr." + (indice_mediu_de_invatare + 1);
                button17.Visible = true;
                label15.Text = dt.Rows[indice_mediu_de_invatare]["Intrebare"].ToString().Trim();
                label16.Text = dt.Rows[indice_mediu_de_invatare]["Var_a"].ToString().Trim();
                label17.Text = dt.Rows[indice_mediu_de_invatare]["Var_b"].ToString().Trim();
                label18.Text = dt.Rows[indice_mediu_de_invatare]["Var_c"].ToString().Trim();
                ok_a = 0;
                ok_b = 0;
                ok_c = 0;
                ok1 = 0;
                ok2 = 0;
                ok3 = 0;

                label16.BackColor = Color.Transparent;
                label16.ForeColor = Color.White;
                label17.BackColor = Color.Transparent;
                label17.ForeColor = Color.White;
                label18.BackColor = Color.Transparent;
                label18.ForeColor = Color.White;
                button11.BackColor = Color.White;
                button12.BackColor = Color.White;
                button13.BackColor = Color.White;
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
            }


        }

        private void button20_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
            nu_mai_pot = 1;
            pictureBox1.Image = null;
            pictureBox1.Update();
            pictureBox2.Image = null;
            pictureBox2.Update();
            pictureBox3.Image = null;
            pictureBox3.Update();
            pictureBox4.Image = null;
            pictureBox4.Update();
            pictureBox5.Image = null;
            pictureBox5.Update();
            pictureBox6.Image = null;
            pictureBox6.Update();
            nr_rasp_corecte = 0;
            nr_rasp_gresite = 0;
            listBox1.Items.Clear();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            tabControl1.SelectedIndex = 9;
            label48.Visible = false;
            textBox9.Visible = false;
            label49.Visible = false;
            groupBox10.Visible = false;
            button23.Visible = false;

        }

        private void button22_Click(object sender, EventArgs e)
        {



        }

        int indice_raspuns_verificare;

        private void button23_Click(object sender, EventArgs e)
        {

        }

        private void button24_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            pictureBox11.Visible = false;
            textBox2.PasswordChar = '\0';
            pictureBox10.Visible = true;
            label55.Text = "Ascunde parola";
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            pictureBox11.Visible = true;
            textBox2.PasswordChar = '*';
            pictureBox10.Visible = false;
            label55.Text = "Afiseaza parola";
        }

        private void label55_Click(object sender, EventArgs e)
        {
            if (pictureBox11.Visible == true)
            {
                pictureBox11.Visible = false;
                textBox2.PasswordChar = '\0';
                pictureBox10.Visible = true;
                label55.Text = "Ascunde parola";
            }
            else
            {
                pictureBox11.Visible = true;
                textBox2.PasswordChar = '*';
                pictureBox10.Visible = false;
                label55.Text = "Afiseaza parola";
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            string nume = textBox3.Text;
            string prenume = textBox4.Text;
            string email = textBox5.Text;
            string username = textBox6.Text;
            string parola = textBox7.Text;
            string intrebare = textBox8.Text;
            this.clientiTableAdapter.Fill(database1DataSet.Clienti);
            DataTable dt = database1DataSet.Clienti;
            int i, okemail = 0, okusername = 0;
            for (i = 0; i < dt.Rows.Count; i++)
            {

                if (dt.Rows[i]["Username"].ToString().CompareTo(username) == 0)
                {
                    MessageBox.Show("Acest username este deja utilizat, incearca altul.");
                    textBox6.Text = "";
                    okusername = 1;
                }
                if (dt.Rows[i]["E-mail"].ToString().CompareTo(email) == 0)
                {
                    MessageBox.Show("Acest e-mail a fost deja folosit pentru creeare altui cont, foloseste altul.");
                    textBox5.Text = "";
                    okemail = 1;
                }
            }
            if (textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "")
            {
                
                 
                 
                    this.clientiTableAdapter.InsertQuery_inregistrari(nume, prenume, email, username, parola, nr_examene_admise, nr_examene_picate, nr_examene_admise, nr_examene_picate, intrebare);

                    this.clientiTableAdapter.Update(this.database1DataSet.Clienti);
                    this.clientiTableAdapter.Fill(this.database1DataSet.Clienti);
                    MessageBox.Show("Te-ai inregistrat cu succes! Acum logheaza-te.");
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    tabControl1.SelectedIndex = 0;
               

            }
            else if (!(textBox3.Text.Trim() != "" && textBox4.Text.Trim() != "" && textBox5.Text.Trim() != "" && textBox6.Text.Trim() != "" && textBox7.Text.Trim() != ""&&textBox8.Text.Trim()!=""))
            {
                if (okemail == 0 && okusername == 0)
                    MessageBox.Show("Completeaza toate datele personale!");
                else { okemail = 0; okusername = 0; }
                //copiaza din bin debug database1.sdf in windowsformapplication1 (folderul principal)
            
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            
        }

        private void button22_Click_1(object sender, EventArgs e)
        {
            if (textBox13.Text == "")
                MessageBox.Show("Nu s-a introdus niciun username sau e-mail, introduceti unul!");
            else
            {
                string user_sau_id = textBox13.Text;

                this.clientiTableAdapter.Fill(database1DataSet.Clienti);
                DataTable dt = this.database1DataSet.Clienti;
                int i;
                int ok = 0;
                for (i = 0; i < dt.Rows.Count; i++)
                    if (user_sau_id == dt.Rows[i]["Username"].ToString() || user_sau_id == dt.Rows[i]["E-mail"].ToString())
                    {
                        label48.Visible = true;
                        textBox9.Visible = true;
                        button23.Visible = true;

                        ok = 1;
                        indice_raspuns_verificare = i;
                        break;

                    }
                if (ok == 0)
                    MessageBox.Show("Nu exista vreun cont cu acest username sau e-mail!");
            }
        }

        private void button23_Click_1(object sender, EventArgs e)
        {
            if (textBox9.Text == "")
                MessageBox.Show("Nu s-a introdus niciun raspuns, introduceti unul!");
            else
            {
                int ok = 0;
                string raspuns = textBox9.Text;
                this.clientiTableAdapter.Fill(database1DataSet.Clienti);
                DataTable dt = this.database1DataSet.Clienti;
                if (raspuns == dt.Rows[indice_raspuns_verificare]["Intrebare_parola"].ToString())
                {
                    label49.Visible = true;
                    label49.Text = "Parola actuala a contului este: " + dt.Rows[indice_raspuns_verificare]["Parola"];
                    groupBox10.Visible = true;
                    ok = 1;

                }
                else MessageBox.Show("Raspunsul intrebarii de siguranta nu este corect!");
            }








        }

        private void button24_Click_1(object sender, EventArgs e)
        {
            if (textBox10.Text == "" || textBox11.Text == "" || textBox12.Text == "")
                MessageBox.Show("Completeaza toate casutele!");
            else
            {
                this.clientiTableAdapter.Fill(database1DataSet.Clienti);
                DataTable dt = this.database1DataSet.Clienti;
                if (textBox10.Text != dt.Rows[indice_raspuns_verificare]["Parola"].ToString())
                    MessageBox.Show("Parola actuala incorecta!");
                else if (textBox11.Text != textBox12.Text)
                    MessageBox.Show("Cele doua parole noi nu coincid, rescrie din nou parola care trebuie reintrodusa!");
                else
                {
                    this.clientiTableAdapter.UpdateQuery_parola(textBox11.Text, indice_raspuns_verificare + 1);
                    this.clientiTableAdapter.Update(this.database1DataSet.Clienti);
                    this.clientiTableAdapter.Fill(this.database1DataSet.Clienti);
                    MessageBox.Show("Parola schimbata cu succes!");
                    tabControl1.SelectedIndex = 0;
                    textBox9.Text = textBox10.Text = textBox11.Text = textBox12.Text = textBox13.Text = "";
                }
            }

        }

        private void button25_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            textBox9.Text = textBox10.Text = textBox11.Text = textBox12.Text = textBox13.Text = "";

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            button6.Visible = false;
            groupBox1.Visible = false;
            
            label41.Visible = false;
            label42.Visible = false;
            label43.Visible = false;

            label19.Text = "26 Intrebari initiale";
            button7.Visible = true;
            button17.Visible = false;
            button18.Visible = false;
            button19.Visible = false;
            label23.Visible = true;
            counter = 1801;
            timer1 = new Timer();
            label23.Font = new Font("Microsoft Sans", 12, FontStyle.Regular);
            timer1.Interval = 1000; // 1 second
            timer1.Start();

            timer1.Tick += new EventHandler(timer1_Tick);

            nr_rasp_corecte = 0;
            nr_rasp_gresite = 0;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            tabControl1.SelectedIndex = 5;
            int i;
            this.intrebariTableAdapter.Fill(this.database1DataSet.Intrebari);
            DataTable dt = this.database1DataSet.Intrebari;


            for (i = 0; i < dt.Rows.Count; i++)
                lista_intrebari.Add(i + 1);

            
            lista_intrebari=Randomize<int>(lista_intrebari);
           
                
            indice = 0;



            ok1 = 0;
            ok2 = 0;
            ok3 = 0;
            label16.BackColor = Color.Transparent;
            label16.ForeColor = Color.White;
            label17.BackColor = Color.Transparent;
            label17.ForeColor = Color.White;
            label18.BackColor = Color.Transparent;
            label18.ForeColor = Color.White;
            button11.BackColor = Color.White;
            button12.BackColor = Color.White;
            button13.BackColor = Color.White;
            label15.Text = dt.Rows[lista_intrebari[indice] - 1]["Intrebare"].ToString().Trim();
            label16.Text = dt.Rows[lista_intrebari[indice] - 1]["Var_a"].ToString().Trim();
            label17.Text = dt.Rows[lista_intrebari[indice] - 1]["Var_b"].ToString().Trim();
            label18.Text = dt.Rows[lista_intrebari[indice] - 1]["Var_c"].ToString().Trim();


            if (dt.Rows[lista_intrebari[indice] - 1]["poza"].ToString().Length != 0)
            {
                string path = Directory.GetCurrentDirectory().Remove(Directory.GetCurrentDirectory().Length - 9);
                Bitmap image = new Bitmap(path + "\\pozele\\" + dt.Rows[lista_intrebari[indice] - 1]["poza"].ToString());
                pictureBox1.Visible = true;
                pictureBox1.Image = (Image)image;
            }
            else pictureBox1.Image = null;
            label20.Text = 26 - indice + " " + "Intrebari ramase";
            label21.Text = nr_rasp_corecte + " Intrebari exacte";
            label22.Text = nr_rasp_gresite + " Intrebari gresite";
        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            button15.Visible = false;
            groupBox8.Visible = false;
            button20.Visible = true;
            label41.Visible = false;
            label42.Visible = false;
            label43.Visible = false;
            label19.Text = "Timp de lucru: ∞";
            button7.Visible = false;
            button17.Visible = true;
            button18.Visible = true;
            button19.Visible = true;
            counter = 999999999;
            label23.Visible = false;
            tabControl1.SelectedIndex = 5;
            nr_rasp_corecte = 0;
            nr_rasp_gresite = 0;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;

            tabControl1.SelectedIndex = 5;

            this.intrebariTableAdapter.Fill(this.database1DataSet.Intrebari);
            DataTable dt = this.database1DataSet.Intrebari;

            ok1 = 0;
            ok2 = 0;
            ok3 = 0;
            label16.BackColor = Color.Transparent;
            label17.BackColor = Color.Transparent;
            label18.BackColor = Color.Transparent;
            button11.BackColor = Color.White;
            button12.BackColor = Color.White;
            button13.BackColor = Color.White;
            label15.Text = dt.Rows[indice_mediu_de_invatare]["Intrebare"].ToString().Trim();
            label16.Text = dt.Rows[indice_mediu_de_invatare]["Var_a"].ToString().Trim();
            label17.Text = dt.Rows[indice_mediu_de_invatare]["Var_b"].ToString().Trim();
            label18.Text = dt.Rows[indice_mediu_de_invatare]["Var_c"].ToString().Trim();
            if (dt.Rows[indice_mediu_de_invatare]["poza"].ToString().Length != 0)
            {
                string path = Directory.GetCurrentDirectory().Remove(Directory.GetCurrentDirectory().Length - 9);
                Bitmap image = new Bitmap(path + "\\pozele\\" + dt.Rows[indice_mediu_de_invatare]["poza"].ToString());
                pictureBox1.Visible = true;
                pictureBox1.Image = (Image)image;
            }
            else pictureBox1.Visible = false;
            if (dt.Rows[indice_mediu_de_invatare]["poza"].ToString().Length != 0)
            {
                pictureBox1.Visible = true;
                pictureBox1.Image = Image.FromFile(dt.Rows[indice_mediu_de_invatare]["poza"].ToString());
            }
            else pictureBox1.Visible = false;
            label20.Text = "Intrebarea nr." + (indice_mediu_de_invatare + 1);
            label21.Text = nr_rasp_corecte + " Intrebari exacte";
            label22.Text = nr_rasp_gresite + " Intrebari gresite";


        }

        private void button26_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            label3.Text = "Nu exista inca un punctaj maxim in sesiunea curenta";
            label4.Text = "Nu exista inca un punctaj minim in sesiunea curenta";
            nr_rasp_corecte_totale = 0;
            nr_rasp_gresite_totale = 0;
            nr_examene_admise = 0;
            nr_examene_picate = 0;

        }

        private void button27_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


       

       

    }


    }


