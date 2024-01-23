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
    public partial class MainForm : Form
    {
        private static Caricamentocs carica = null;
        public static Finish fine = new Finish();
        private static bool isOpen = false;
        List<string> nAziende = new List<string>();
        List<string> Indirizzi = new List<string>();
        List<string> Citta = new List<string>();
        List<string> Cap = new List<string>();
        List<string> CondizioniPagamento = new List<string>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            textBoxAnno.Text = DateTime.Now.Year.ToString();

            var listaClienti = Provider.ClienteProvider.NomiAziende();

            foreach (var item in listaClienti)
            {
                //Rimuove SRL
                item.RagioneSociale = Regex.Replace(item.RagioneSociale, @" s\.?r\.?l\.?", "", RegexOptions.IgnoreCase);
                //Rimuove SPA
                item.RagioneSociale = Regex.Replace(item.RagioneSociale, @" s\.?p\.?a\.?", "", RegexOptions.IgnoreCase);
                nAziende.Add(item.RagioneSociale.Trim());

                Indirizzi.Add(item.Indirizzo.Trim());

                Cap.Add(item.Cap.Trim());

                Citta.Add(item.Citta.Trim());

                CondizioniPagamento.Add(item.CondizionePagamento.Trim());
            }

            comboBoxNomeAzienda.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxNomeAzienda.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection data = new AutoCompleteStringCollection();
            foreach (var item in nAziende)
            {
                data.Add(item.Trim());
            }
            comboBoxNomeAzienda.AutoCompleteCustomSource = data;
            comboBoxNomeAzienda.DataSource = data;
        }
        public void ScriviSuOfferta(Spire.Doc.Document documento, string path, int nofferta, string datastring, string condizionePagamento)
        {
            if(!ValidateInputs())
            {
                return;
            }

            documento.LoadFromFile(path + "\\" + "Offerta_" + nofferta.ToString("000") + "-" + textBoxAnno.Text + "_" + comboBoxNomeAzienda.Text + "_" + textBoxDescrizioneCartella.Text + ".doc");
            documento.Replace("Azienda", comboBoxNomeAzienda.Text, false, true);
            documento.Replace("Indirizzo", textBoxIndirizzo.Text, false, true);
            documento.Replace("12050,", textBoxCAP.Text, false, true);
            documento.Replace("Nome Cognome", textBoxNomeTecnico.Text, false, true);
            documento.Replace("Città", "", false, true);
            documento.Replace("27 luglio 2022", DateTime.Now.ToString("gg MM yyyy"), false, true);
            documento.Replace("000/", nofferta.ToString() + "/", false, true);
            documento.Replace("/2022", "/" + textBoxAnno.Text, false, true);
            documento.Replace("Sistema di visione per controlli qualità Ceme nuclei mobili", textBoxDescrizioneCartella.Text, false, true);
            documento.Replace("CONDIZIONE_PAGAMENTO", textBoxCondizionePagamento.Text, false, true);
            documento.SaveToFile(path + "\\" + "Offerta_" + nofferta.ToString("000") + "-" + DateTime.Today.Year.ToString() + "_" + comboBoxNomeAzienda.Text + "_" + textBoxDescrizioneCartella.Text + ".doc");
        }
        public void ScriviSuReport(Spire.Doc.Document documento, string path, int nofferta, string datastring)
        {
            documento.LoadFromFile(path + "\\report\\" + "Report_" + nofferta.ToString("000") + "-" + textBoxAnno.Text + "_" + comboBoxNomeAzienda.Text + "_" + textBoxDescrizioneCartella.Text + ".odt");
            documento.Replace("Azienda", comboBoxNomeAzienda.Text, false, true);
            documento.Replace("Indirizzo", textBoxIndirizzo.Text, false, true);
            documento.Replace("12050,", textBoxCAP.Text, false, true);
            documento.Replace("Nome Cognome", textBoxNomeTecnico.Text, false, true);
            documento.Replace("Città", "", false, true);
            documento.Replace("27 luglio 2022", DateTime.Now.ToString("gg MM yyyy"), false, true);
            documento.Replace("000/", nofferta.ToString() + "/", false, true);
            documento.Replace("/2022", "/" + textBoxAnno.Text, false, true);
            documento.Replace("Nome tecnico “NON METTERE IL COGNOME PER PRIVACY”", textBoxNomeTecnico.Text, false, true);
            documento.SaveToFile(path + "\\report\\" + "Report_" + nofferta.ToString("000") + "-" + DateTime.Today.Year.ToString() + "_" + comboBoxNomeAzienda.Text + "_" + textBoxDescrizioneCartella.Text + ".odt");
        }

        public void CleanInput(string strIn)
        {
            // Replace invalid characters with empty strings.
            try
            {
                strIn = Regex.Replace(strIn, @"[^\w\.@-]", " ", RegexOptions.None, TimeSpan.FromSeconds(1));
            }
            // If we timeout when replacing invalid characters,
            // we should return Empty.
            catch (RegexMatchTimeoutException)
            {
                strIn = String.Empty;
            }
        }
        private void buttonCrea_Click(object sender, EventArgs e)
        {
            CleanInput(comboBoxNomeAzienda.Text);
            CleanInput(textBoxDescrizioneCartella.Text);
            CleanInput(textBoxNomeTecnico.Text);
            CleanInput(textBoxIndirizzo.Text);
            CleanInput(textBoxCAP.Text);
            CleanInput(textBoxCondizionePagamento.Text);

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
                List<int> ris2 = new List<int>();
                string[] pathServer = Directory.GetDirectories(Properties.Settings.Default.PathServer + "\\" + textBoxAnno.Text, "*_*");
                for (int i = 0; i < pathServer.Length; i++)
                {
                    string[] ris1 = pathServer[i].Split('\\');
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

                string descrizione = textBoxDescrizioneCartella.Text;
                DateTime data = DateTime.Today;
                string path = Properties.Settings.Default.PathServer + "\\" + textBoxAnno.Text + "\\" + nofferta.ToString("000") + "_" + comboBoxNomeAzienda + "_" + textBoxDescrizioneCartella.Text;
                String dataString = data.ToString("dd MMMM yyyy");
                string condizionePagamento = textBoxCondizionePagamento.Text;
                CopyFilesRecursively(Properties.Settings.Default.PathServer + "\\" + Properties.Settings.Default.CartellaMaster, path, ref nofferta, comboBoxNomeAzienda.Text, ref descrizione);
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

                Process.Start("explorer.exe", path);
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private static void CopyFilesRecursively(string sourcePath, string targetPath, ref int nofferta, string val1, ref string descrizione)
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
        private void comboBoxNomeAzienda_SelectedValueChanged(object sender, EventArgs e)
        {
            textBoxIndirizzo.Text = Indirizzi[comboBoxNomeAzienda.SelectedIndex];
            textBoxCAP.Text = Cap[comboBoxNomeAzienda.SelectedIndex];
            textBoxCitta.Text = Citta[comboBoxNomeAzienda.SelectedIndex];
            textBoxCondizionePagamento.Text = CondizioniPagamento[comboBoxNomeAzienda.SelectedIndex];
        }
        private void btnInfo_Click(object sender, EventArgs e)
        {
            INFO info = new INFO();
            info.ShowDialog();
        }

        private bool ValidateInputs()
        {
            //TODO
            return true;
        }

        private void HighlightError(Control control)
        {
            //TODO
        }
    }
}