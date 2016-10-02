using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Dit.Lms.Api;

namespace Dit.Lms.Gui
{
    public partial class MemberSave : BaseSaveForm
    {
        public RefreshGridDataHandler<Member> _RefreshGridData;
        private Member _Member;

        public MemberSave(Member member, RefreshGridDataHandler<Member> displayGridData)
        {
            _Member = member;
            _RefreshGridData = displayGridData;
            InitializeComponent();
            dlgOpenFile.FileName = string.Empty;
            dlgOpenFile.Filter = "Image Files(*.BMP;*.JPG;*.JPEG;*.GIF)|*.BMP;*.JPG;.JPEG;*.GIF";
            btnDelete.Click += btnDeleteClick;
            btnClear.Click += btnClearClick;
            btnSave.Click += btnSaveClick;
        }

        private void MemberNew_Load(object sender, EventArgs e)
        {
            //bool writable = (_Member == null || _Member.Id == 0 || !Service.MonthlyDepositExists(_Member.Id));
            //txtInitialBalance.ReadOnly = txtPresentBalance.ReadOnly = !writable;
            //if (writable)
            //{
            //    txtInitialBalance.BackColor = txtPresentBalance.BackColor = txtName.BackColor;
            //}
            cmbRelationWithNominee.DataSource = Enum.GetValues(typeof(Relation));
            cmbReligion.DataSource = Enum.GetValues(typeof(Religion));
            DisplayData();
        }

        private void btnSelectPhoto_Click(object sender, EventArgs e)
        {
            DialogResult result = dlgOpenFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                ShowImage(pbxPhoto);
            }
        }

        private void ShowImage(PictureBox picBox)
        {
            try
            {
                using (FileStream stream = File.OpenRead(dlgOpenFile.FileName))
                {
                    Image image = Image.FromStream(stream);
                    Size finalDimension = GenerateFinalDimension(image.Width, image.Height, picBox.Width, picBox.Height);
                    Image resizedImg = new Bitmap(image, finalDimension);
                    picBox.Image = resizedImg;
                    picBox.SizeMode = PictureBoxSizeMode.CenterImage;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //if (picBox.Image != null) picBox.Image.Dispose();
            //Image originalImg = new Bitmap(dlgOpenFile.FileName);
            //Size finalDimension = GenerateFinalDimension(originalImg.Width, originalImg.Height, picBox.Width, picBox.Height);
            //Image resizedImg = new Bitmap(originalImg, finalDimension);
            //Graphics graphix = Graphics.FromImage(originalImg);
            //graphix.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            //picBox.Image = resizedImg;
            //picBox.SizeMode = PictureBoxSizeMode.CenterImage;
            //originalImg.Dispose();
        }

        private Size GenerateFinalDimension(int imgWidth, int imgHeight, int pbxWidth, int pbxHeight)
        {
            double multiplier = 0;
            if (imgHeight > imgWidth)
            {
                if (pbxHeight > pbxWidth)
                {
                    multiplier = (double)pbxWidth / (double)imgWidth;
                }
                else
                {
                    multiplier = (double)pbxHeight / (double)imgHeight;
                }
            }
            else
            {
                if (pbxHeight > pbxWidth)
                {
                    multiplier = (double)imgWidth / (double)pbxWidth;
                }
                else
                {
                    multiplier = (double)imgHeight / (double)pbxHeight;
                }
            }
            return new Size((int)(imgWidth * multiplier), (int)(imgHeight * multiplier));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelectNomineesPhoto_Click(object sender, EventArgs e)
        {
            DialogResult result = dlgOpenFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                ShowImage(pbxNomineePhoto);
            }
        }

        void txtMemberId_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar == 46 || char.IsLetter(e.KeyChar) || e.KeyChar == 32;
        }

        private void txtInitialBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar == 46 && txtInitialBalance.Text.Contains(".") || char.IsLetter(e.KeyChar) || e.KeyChar == 32;
        }

        private void txtPresentBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar == 46 && txtPresentBalance.Text.Contains(".") || char.IsLetter(e.KeyChar) || e.KeyChar == 32;
        }

        private void txtVoterIdNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar == 46 || char.IsLetter(e.KeyChar) || e.KeyChar == 32;
        }

        private void dtpDateOfBirth_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan dateDiff = DateTime.Today.Subtract(dtpDateOfBirth.Value);
            txtAge.Text = string.Format("{0} Years", Math.Floor(dateDiff.TotalDays / 365).ToString());
        }

        protected override void DisplayData()
        {
            txtMemberId.Text = _Member.MemberId.ToString();
            txtEmail.Text = _Member.Email;
            txtInstitution.Text = _Member.Institution;
            cmbReligion.SelectedItem = _Member.Religion;
            txtFatherName.Text = _Member.FathersName;
            txtInitialBalance.Text = _Member.InitialBalance.ToString();
            txtMotherName.Text = _Member.MothersName;
            txtName.Text = _Member.Name;
            txtNominee.Text = _Member.Nominee;
            txtNationality.Text = string.IsNullOrEmpty(_Member.Nationality) ? "Bangladeshi" : _Member.Nationality;
            txtMobileNo.Text = _Member.Mobile;
            txtPermanentAddress.Text = _Member.PermanentAddress;
            txtPresentAddress.Text = _Member.PresentAddress;
            txtPresentBalance.Text = _Member.PresentBalance.ToString();
            txtVoterIdNo.Text = _Member.VoterIdNo.ToString();
            cmbRelationWithNominee.SelectedItem = _Member.RelationWithNominee;
            dtpDateOfBirth.Value = _Member.DateOfBirth;
            btnDelete.Enabled = _Member.Id != 0;
            string photo = Path.Combine(ImageFolder, _Member.Photo);
            pbxPhoto.SizeMode = PictureBoxSizeMode.CenterImage;
            pbxPhoto.ImageLocation = photo;
            string nomineePhoto = Path.Combine(ImageFolder, _Member.NomineesPhoto);
            pbxNomineePhoto.SizeMode = PictureBoxSizeMode.CenterImage;
            pbxNomineePhoto.ImageLocation = nomineePhoto;
        }

        protected override void CollectData()
        {
            _Member.MemberId = int.Parse(txtMemberId.Text.Trim());
            _Member.Email = txtEmail.Text.Trim();
            _Member.Religion = (Religion)Enum.Parse(typeof(Religion), cmbReligion.SelectedItem.ToString());
            _Member.Institution = txtInstitution.Text.Trim();
            _Member.Name = txtName.Text;
            _Member.MothersName = txtMotherName.Text;
            _Member.FathersName = txtFatherName.Text;
            _Member.DateOfBirth = dtpDateOfBirth.GetDate();
            _Member.InitialBalance = double.Parse(txtInitialBalance.Text);
            _Member.Nominee = txtNominee.Text;
            _Member.Nationality = txtNationality.Text;
            _Member.Mobile = txtMobileNo.Text;
            _Member.PermanentAddress = txtPermanentAddress.Text;
            _Member.PresentAddress = txtPresentAddress.Text;
            _Member.PresentBalance = double.Parse(txtPresentBalance.Text);
            _Member.RelationWithNominee = (Relation)Enum.Parse(typeof(Relation), cmbRelationWithNominee.Text);
            _Member.VoterIdNo = long.Parse(txtVoterIdNo.Text);
            _Member.IsActive = true;
        }

        protected override void ClearData()
        {
            _Member = new Member();
            DisplayData();
        }

        protected override void InitData() { }

        protected override bool ValidateData()
        {
            return true;
        }

        protected override void RefreshGridData()
        {
            _RefreshGridData(_Member);
        }

        protected override void DeleteData()
        {
            Service.DeleteMember(_Member.Id);
            _Member.IsActive = false;
        }

        protected override void SaveData()
        {
            _Member = Service.SaveMember(_Member);
        }

        protected override void HookAnything()
        {
            string photo = Path.Combine(ImageFolder, _Member.Photo);
            if (File.Exists(photo))
            {
                File.Delete(photo);
            }
            pbxPhoto.Image.Save(photo);
            string nomineePhoto = Path.Combine(ImageFolder, _Member.NomineesPhoto);
            if (File.Exists(nomineePhoto))
            {
                File.Delete(nomineePhoto);
            }
            pbxNomineePhoto.Image.Save(nomineePhoto);
        }
    }
}
