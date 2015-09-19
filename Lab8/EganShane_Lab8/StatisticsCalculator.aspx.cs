using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EganShane_Lab8
{
    public partial class StatisticsCalculator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // If the user triggered a page reload
            if (IsPostBack)
            {
                try
                {
                    // Grab the user inputed data
                    var firstNum = Convert.ToDouble(txtFirstNum.Text);
                    var secondNum = Convert.ToDouble(txtSecondNum.Text);
                    var thirdNum = Convert.ToDouble(txtThirdNum.Text);

                    // Clear all the fields
                    ClearFields();

                    // Display the new results
                    lblMax.Text += GetMaxNum(firstNum, secondNum, thirdNum);
                    lblMin.Text += GetMinNum(firstNum, secondNum, thirdNum);
                    lblAvg.Text += GetAvg(firstNum, secondNum, thirdNum);
                    lblTotal.Text += GetTotal(firstNum, secondNum, thirdNum);
                }
                catch (Exception ex)
                {
                    ClearFields();
                    lblError.Visible = true;
                }
            }
            else
            {
                lblError.Visible = false;
            }
        }

        protected double GetMaxNum(double first, double second, double third)
        {
            if ((first > second) && (first > third))
            {
                return first;
            }
            else if ((second > first) && (second > third))
            {
                return second;
            }
            return third;
        }

        protected double GetMinNum(double first, double second, double third)
        {
            if ((first < second) && (first < third))
            {
                return first;
            }
            else if ((second < first) && (second < third))
            {
                return second;
            }
            return third;
        }

        protected double GetAvg(double first, double second, double third)
        {
            return ((first + second + third) / 3);
        }

        protected double GetTotal(double first, double second, double third)
        {
            return first + second + third;
        }

        protected void ClearFields()
        {
            // Clear text fields
            txtFirstNum.Text = "";
            txtSecondNum.Text = "";
            txtThirdNum.Text = "";

            // Reset the results
            lblMax.Text = "Maximum: ";
            lblMin.Text = "Minimum: ";
            lblAvg.Text = "Average: ";
            lblTotal.Text = "Total: ";

            // Hide the error
            lblError.Visible = false;
        }
    }
}