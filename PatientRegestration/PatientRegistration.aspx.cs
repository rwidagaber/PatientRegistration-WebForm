using PatientRegestration.Data;
using PatientRegestration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PatientRegestration
{
    public partial class PatientRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            
            if (!Page.IsValid)
            {
                return;
            }

            
            Patient patient = new Patient
            {
                FirstName = txtFirstName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Gender = ddlGender.SelectedValue,

            };

         
            DateTime dateOfBirth;

            if (!DateTime.TryParse(
                    txtDateOfBirth.Text,
                    out dateOfBirth))


            {
                lblMessage.Text = "Please enter a valid date of birth.";
                lblMessage.CssClass = "alert alert-danger d-block";
                return;
            }

            patient.DateOfBirth = dateOfBirth;

            try
            {
              
                PatientRepository repository =
                    new PatientRepository();

                
                long fileNumber =
                    repository.RegisterPatient(patient);

             
                lblMessage.Text =
                    $"Patient registered successfully. File Number: {fileNumber}";

                lblMessage.CssClass =
                    "alert alert-success d-block";

               
                ClearForm();
            }
            catch (Exception ex)
            {
                lblMessage.Text =
                    "Error: " + ex.Message;

                lblMessage.CssClass =
                    "alert alert-danger d-block";
            }
        }

        private void ClearForm()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPhone.Text = "";
            txtDateOfBirth.Text = "";
            ddlGender.SelectedIndex = 0;
           
        }
    }
}