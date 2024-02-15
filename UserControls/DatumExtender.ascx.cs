using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace ImagesUpload.UserControls
{
    public partial class DatumExtender : System.Web.UI.UserControl
    {

        #region Properties...

        private System.Globalization.DateTimeFormatInfo myDTFI =
            new System.Globalization.CultureInfo("fr-FR", false).DateTimeFormat;
        private string greska_Prazno = "Datum je obavezno polje!";
        private string greska_NepravilanUnos = "Datum nije korektno unet!";
        private string greska_VeceOdMax = "Datum je izvan predviðenih granica!";
        private string greska_ManjeOdMin = "Datum je izvan predviðenih granica!";
        private string greska_PorukaZaValidationSummary = "Datum nije korektno unet!";
        private DefaultVrednosti defaultDatum = DefaultVrednosti.Danas;
        private byte prelomnaGodina = 30;
        private bool danasnjiDatum = false;
        private bool prvoUcitavanje
        {
            get
            {
                if (ViewState["PrvoUcitavanje"] != null)
                {
                    return (bool)ViewState["PrvoUcitavanje"];
                }
                else
                {
                    return true;
                }
            }
            set
            {
                ViewState["PrvoUcitavanje"] = value;
            }
        }



        public enum DefaultVrednosti
        {
            Danas,
            MinVrednost,
            MaxVrednost
        };
        public bool DozvoliPrazno
        {
            get
            {
                return MaskedEditValidator1.IsValidEmpty;
            }
            set
            {
                if (value == true)
                    MaskedEditValidator1.IsValidEmpty = value;
                else
                    MaskedEditValidator1.IsValidEmpty = false;
            }
        }
        public string ValidationGroup
        {
            get
            {
                return txtDatum.ValidationGroup;
            }
            set
            {
                txtDatum.ValidationGroup = value;
                MaskedEditValidator1.ValidationGroup = value;
            }
        }
        public DateTime Value
        {
            get
            {
                if (txtDatum.Text != "")
                {
                    try
                    {
                        DateTime dtTemp = Convert.ToDateTime(txtDatum.Text, myDTFI);
                        return dtTemp;
                    }
                    catch
                    {
                        if (defaultDatum == DefaultVrednosti.MinVrednost)
                            return DateTime.MinValue;
                        else if (defaultDatum == DefaultVrednosti.MaxVrednost)
                            return DateTime.MaxValue;
                        else
                            return DateTime.Now;
                    }
                }
                else
                {
                    if (defaultDatum == DefaultVrednosti.MinVrednost)
                        return DateTime.MinValue;
                    else if (defaultDatum == DefaultVrednosti.MaxVrednost)
                        return DateTime.MaxValue;
                    else
                        return DateTime.Now;
                }
            }
            set
            {
                txtDatum.Text = value.ToString("dd/MM/yyyy",
                    System.Globalization.CultureInfo.InvariantCulture);
            }
        }
        public DefaultVrednosti DefaultDatum
        {
            get { return defaultDatum; }
            set { defaultDatum = value; }
        }

        public bool DanasnjiDatum
        {
            get { return danasnjiDatum; }
            set { danasnjiDatum = value; }
        }



        public string Text
        {
            get { return txtDatum.Text; }
            set { txtDatum.Text = value; }
        }
        public string Text_YMD
        {
            get
            {
                return this.Value.ToString("yyyy-MM-dd",
                  System.Globalization.CultureInfo.InvariantCulture);
            }
        }
        public byte PrelomnaGodina
        {
            get
            {
                return this.prelomnaGodina;
            }
            set
            {
                this.prelomnaGodina = value;
            }
        }
        public bool Enabled
        {
            get { return txtDatum.Enabled; }
            set
            {
                txtDatum.Enabled = value;
                MaskedEditValidator1.Enabled = value;
            }
        }
        public bool ReadOnly
        {
            get { return txtDatum.ReadOnly; }
            set
            {
                txtDatum.ReadOnly = value;
            }
        }
        public string MinimumValue
        {
            get { return MaskedEditValidator1.MinimumValue; }
            set
            {
                try
                {
                    DateTime dtTemp = DateTime.Parse(value, myDTFI);
                    MaskedEditValidator1.MinimumValue = value;
                }
                catch
                {
                    MaskedEditValidator1.MinimumValue = DateTime.MinValue.ToString("dd/MM/yyyy",
                        System.Globalization.CultureInfo.InvariantCulture);
                }
            }
        }
        public string MaximumValue
        {
            get { return MaskedEditValidator1.MaximumValue; }
            set
            {
                if (value == "Danas")
                {
                    MaskedEditValidator1.MaximumValue = DateTime.Now.ToString("dd/MM/yyyy",
                        System.Globalization.CultureInfo.InvariantCulture);
                }
                else
                {
                    try
                    {
                        DateTime dtTemp = DateTime.Parse(value, myDTFI);
                        MaskedEditValidator1.MaximumValue = value;
                    }
                    catch
                    {
                        MaskedEditValidator1.MinimumValue = DateTime.MaxValue.ToString("dd/MM/yyyy",
                            System.Globalization.CultureInfo.InvariantCulture);
                    }
                }
            }
        }
        public bool AutoPostBack
        {
            get { return txtDatum.AutoPostBack; }
            set { txtDatum.AutoPostBack = value; }
        }
        public short TabIndex
        {
            get { return txtDatum.TabIndex; }
            set { txtDatum.TabIndex = value; }
        }
        public System.Drawing.Color BackColor
        {
            get { return txtDatum.BackColor; }
            set { txtDatum.BackColor = value; }
        }
        public string Greska_Prazno
        {
            get { return greska_Prazno; }
            set
            {
                greska_Prazno = value;
                MaskedEditValidator1.EmptyValueBlurredText = greska_Prazno;
            }
        }
        public string Greska_NepravilanUnos
        {
            get { return greska_NepravilanUnos; }
            set
            {
                greska_NepravilanUnos = value;
                MaskedEditValidator1.InvalidValueBlurredMessage = greska_NepravilanUnos;
            }
        }
        public string Greska_VeceOdMax
        {
            get { return greska_VeceOdMax; }
            set
            {
                greska_VeceOdMax = value;
                MaskedEditValidator1.MaximumValueBlurredMessage = greska_VeceOdMax;
            }
        }
        public string Greska_ManjeOdMin
        {
            get { return greska_ManjeOdMin; }
            set
            {
                greska_ManjeOdMin = value;
                MaskedEditValidator1.MinimumValueBlurredText = greska_ManjeOdMin;
            }
        }
        public string Greska_PorukaZaValidationSummary
        {
            get { return greska_PorukaZaValidationSummary; }
            set
            {
                greska_PorukaZaValidationSummary = value;
                MaskedEditValidator1.EmptyValueMessage = greska_PorukaZaValidationSummary;
                MaskedEditValidator1.InvalidValueMessage = greska_PorukaZaValidationSummary;
            }
        }

        #endregion

        #region Methods...

        protected void Page_Load(object sender, EventArgs e)
        {
            if (defaultDatum == DefaultVrednosti.Danas && txtDatum.Text == "" && prvoUcitavanje)
            {
                txtDatum.Text = DateTime.Now.ToString("dd/MM/yyyy",
                    System.Globalization.CultureInfo.InvariantCulture);
                prvoUcitavanje = false;
            }
        }

        protected void Page_Pre(object sender, EventArgs e)
        {

        }
        override public void Focus()
        {
            txtDatum.Focus();
        }

        #endregion
        protected void CalendarExtender1_PreRender(object sender, EventArgs e)
        {
            if ((danasnjiDatum == true))
            {
                txtDatum.Text = DateTime.Now.ToString("dd/MM/yyyy",
                  System.Globalization.CultureInfo.InvariantCulture);
                prvoUcitavanje = false;
            }
        }

    }
}