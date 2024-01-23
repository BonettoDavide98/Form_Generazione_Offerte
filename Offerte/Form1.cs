using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Spire.Doc.Fields;
using Spire.Doc.Documents;
using Spire.Doc;
using System.Drawing;
using Spire.Doc.Formatting;
using System.Threading;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace Offerte
{
    public partial class Form1 : Form
    {
        private static Caricamentocs carica = null;
        public static Finish fine = new Finish();
        private static bool isOpen = false;
        int anno = DateTime.Now.Year;
        string val1 = "";
        List<string> nAziende = new List<string>();
        List<string> Indirizzi = new List<string>();
        List<string> Citta = new List<string>();
        List<string> Cap = new List<string>();
        List<string> CondizioniPagamento = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            txt_anno.Text = anno.ToString();
            var listaClienti = Provider.ClienteProvider.NomiAziende();

            foreach (var item in listaClienti)
            {
                if (item.RagioneSociale.Contains("srl"))
                    nAziende.Add(item.RagioneSociale.Replace("srl", " "));
                else if (item.RagioneSociale.Contains("s.r.l."))
                    nAziende.Add(item.RagioneSociale.Replace("s.r.l.", " "));
                else if (item.RagioneSociale.Contains("SRL"))
                    nAziende.Add(item.RagioneSociale.Replace("SRL", " "));
                else if (item.RagioneSociale.Contains("S.p.A."))
                    nAziende.Add(item.RagioneSociale.Replace("S.p.A.", " "));
                else
                    nAziende.Add(item.RagioneSociale);

                Indirizzi.Add(item.Indirizzo);
                Cap.Add(item.Cap);
                Citta.Add(item.Citta);
                CondizioniPagamento.Add(item.CondizionePagamento);
            }

            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection data = new AutoCompleteStringCollection();
            foreach (var item in nAziende)
            {
                data.Add(item);
            }
            comboBox1.AutoCompleteCustomSource = data;
            comboBox1.DataSource = data;
        }
        public void ScriviSuOfferta(Spire.Doc.Document documento, string path, int nofferta, string datastring, string condizionePagamento)
        {
            documento.LoadFromFile(path + "\\" + "Offerta_" + nofferta.ToString("000") + "-" + DateTime.Today.Year.ToString() + "_" + val1 + "_" + txt_descrizione.Text + ".doc");
            documento.Replace("Azienda", val1, false, true);
            documento.Replace("Indirizzo", txt_Indirizzo.Text, false, true);
            documento.Replace("12050,", txt_CAP.Text, false, true);
            documento.Replace("Nome Cognome", txt_nome.Text, false, true);
            documento.Replace("Città", "", false, true);
            documento.Replace("27 luglio 2022", datastring, false, true);
            documento.Replace("000/", nofferta.ToString() + "/", false, true);
            documento.Replace("/2022", "/" + anno, false, true);
            documento.Replace("Sistema di visione per controlli qualità Ceme nuclei mobili", txt_descrizione.Text, false, true);
            documento.Replace("CONDIZIONE_PAGAMENTO", condizionePagamento, false, true);
            documento.SaveToFile(path + "\\" + "Offerta_" + nofferta.ToString("000") + "-" + DateTime.Today.Year.ToString() + "_" + val1 + "_" + txt_descrizione.Text + ".doc");
        }
        public void ScriviSuReport(Spire.Doc.Document documento, string path, int nofferta, string datastring)
        {
            documento.LoadFromFile(path + "\\report\\" + "Report_" + nofferta.ToString("000") + "-" + DateTime.Today.Year.ToString() + "_" + val1 + "_" + txt_descrizione.Text + ".odt");
            documento.Replace("Azienda", val1, false, true);
            documento.Replace("Indirizzo", txt_Indirizzo.Text, false, true);
            documento.Replace("12050,", txt_CAP.Text, false, true);
            documento.Replace("Nome Cognome", txt_nome.Text, false, true);
            documento.Replace("Città", "", false, true);
            documento.Replace("27 luglio 2022", datastring, false, true);
            documento.Replace("000/", nofferta.ToString() + "/", false, true);
            documento.Replace("/2022", "/" + anno, false, true);
            documento.Replace("Nome tecnico “NON METTERE IL COGNOME PER PRIVACY”", txt_nomeTecnico.Text, false, true);
            documento.SaveToFile(path + "\\report\\" + "Report_" + nofferta.ToString("000") + "-" + DateTime.Today.Year.ToString() + "_" + val1 + "_" + txt_descrizione.Text + ".odt");
        }

        public static string CleanInput(string strIn)
        {
            // Replace invalid characters with empty strings.
            try
            {
                return Regex.Replace(strIn, @"[^\w\.@-]", " ", RegexOptions.None, TimeSpan.FromSeconds(1));
            }
            // If we timeout when replacing invalid characters,
            // we should return Empty.
            catch (RegexMatchTimeoutException)
            {
                return String.Empty;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txt_descrizione.Text = CleanInput(txt_descrizione.Text);
            txt_nomeTecnico.Text = CleanInput(txt_nomeTecnico.Text);
            txt_Indirizzo.Text = CleanInput(txt_Indirizzo.Text);
            txt_nome.Text = CleanInput(txt_nome.Text);
            txt_CAP.Text = CleanInput(txt_CAP.Text);
            txtCondizionePagamento.Text = CleanInput(txtCondizionePagamento.Text);

            try
            {
                Thread splashThread = new Thread(new ThreadStart(
                     delegate
                     {
                         carica = new Caricamentocs();
                         Application.Run(carica);
                     }
                     ));

                splashThread.SetApartmentState(ApartmentState.STA);
                splashThread.Start();

                Thread.Sleep(50);

                int nofferta = 1;
                val1 = comboBox1.Text.Trim();
                List<int> ris2 = new List<int>();
                string[] pippo = Directory.GetDirectories(Properties.Settings.Default.PathServer + "\\" + txt_anno.Text, "*_*");
                for (int i = 0; i < pippo.Length; i++)
                {
                    string[] ris1 = pippo[i].Split('\\');
                    string[] ris3 = (ris1[ris1.Length - 1].Split('_'));
                    if (Convert.ToInt32(ris3[0]) != 999)
                    {
                        ris2.Add(Convert.ToInt32(ris3[0]));
                    }
                }
                // ris2.Sort();
                if (ris2.Count == 0)
                {
                    nofferta = 1;
                }
                else
                {
                    nofferta = ris2.Last() + 1;
                }

                string descrizione = txt_descrizione.Text;
                DateTime data = DateTime.Today;
                string path = Properties.Settings.Default.PathServer + "\\" + txt_anno.Text + "\\" + nofferta.ToString("000") + "_" + val1 + "_" + txt_descrizione.Text;
                String dataString = data.ToString("dd MMMM yyyy");
                string condizionePagamento = txtCondizionePagamento.Text;
                CopyFilesRecursively(Properties.Settings.Default.PathServer + "\\" + Properties.Settings.Default.CartellaMaster, path, ref nofferta, ref val1, ref descrizione);
                Directory.CreateDirectory(path);

                System.Threading.Tasks.Task T_Offerta = System.Threading.Tasks.Task.Run(() =>
                {
                    try
                    {
                        Spire.Doc.Document Offerta = new Spire.Doc.Document();
                        ScriviSuOfferta(Offerta, path, nofferta, dataString, condizionePagamento);
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.ToString());
                    }

                });

                System.Threading.Tasks.Task T_Report = System.Threading.Tasks.Task.Run(() =>
                {
                    try
                    {
                        Spire.Doc.Document Report = new Spire.Doc.Document();
                        ScriviSuReport(Report, path, nofferta, dataString);
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.ToString());
                    }
                });

                System.Threading.Tasks.Task.WaitAll(T_Offerta, T_Report);

                if (carica != null)
                {
                    carica.Invoke(new Action(() =>
                    {
                        carica?.Close();
                        carica = null;
                        isOpen = false;
                    }));
                }
                txt_descrizione.Clear();
                txt_nomeTecnico.Clear();
                //fine.ShowDialog();
                Process.Start("explorer.exe", path);
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private static void CopyFilesRecursively(string sourcePath, string targetPath, ref int nofferta, ref string val1, ref string descrizione)
        {
            foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
                Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
            foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
            {
                if (newPath == Properties.Settings.Default.PathServer + "\\" + Properties.Settings.Default.CartellaMaster + "\\" + Properties.Settings.Default.FileOfferte)
                    File.Copy(newPath, newPath.Replace(sourcePath + "\\" + Properties.Settings.Default.FileOfferte, targetPath + "\\" + "Offerta_" + nofferta.ToString("000") + "-" + DateTime.Today.Year.ToString() + "_" + val1 + "_" + descrizione + ".doc"), true);
                else if (newPath == Properties.Settings.Default.PathServer + "\\" + Properties.Settings.Default.CartellaMaster + "\\report\\" + Properties.Settings.Default.FileReport)
                    File.Copy(newPath, newPath.Replace(sourcePath + "\\report\\" + Properties.Settings.Default.FileReport, targetPath + "\\" + "report" + "\\" + "Report_" + nofferta.ToString("000") + "-" + DateTime.Today.Year.ToString() + "_" + val1 + "_" + descrizione + ".odt"), true);
                else
                    File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
            }
        }
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            txt_Indirizzo.Text = Indirizzi[comboBox1.SelectedIndex];
            txt_CAP.Text = Cap[comboBox1.SelectedIndex];
            txt_citta.Text = Citta[comboBox1.SelectedIndex];
            txtCondizionePagamento.Text = CondizioniPagamento[comboBox1.SelectedIndex];
        }
        private void btnInfo_Click(object sender, EventArgs e)
        {
            INFO info = new INFO();
            info.ShowDialog();
        }
    }
}