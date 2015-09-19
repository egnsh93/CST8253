using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CourseRegistration : Page
{
    private readonly CheckBoxList _cblAvailableCourses = new CheckBoxList();

    protected void Page_Load(object sender, EventArgs e)
    {
        lblError.Visible = false;
        studentInfo.Visible = false;
        frmCourseRegistration.Visible = true;

        DisplayAvailableCourses();
    }

    protected void DisplayAvailableCourses()
    {
        // Loop through each course in the list
        foreach (Course c in Helper.GetCourses())
        {
            // Add the course info to the checkbox control
            _cblAvailableCourses.Items.Add(c.Code + " " + c.Title + " - " + c.WeeklyHours + " per week");
        }

        // Add the checkbox list to the placeholder
        phAvailableCourses.Controls.Add(_cblAvailableCourses);
    }

    protected void ValidateForm()
    {
        // Get the student name
        var studentName = txtStudentName.Text;

        // Get the type of student from radio button
        var studentType = pnlStudentType.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
        if (studentType == null) return;

        Student student = null;

        // Create a new student instance of the appropriate type
        switch (studentType.Text)
        {
            case "Full Time" :
                student = new FullTimeStudent(studentName);
                break;
            case "Part Time" :
                student = new PartTimeStudent(studentName);
                break;
            case "Co-op" :
                student = new CoopStudent(studentName);
                break;
        }

        var error = false;

        // Iterate through the checkbox list
        for (var i = 0; i < _cblAvailableCourses.Items.Count; i++)
        {
            // If an item is selected
            if (!_cblAvailableCourses.Items[i].Selected) continue;

            // Attempt to register the student in the course
            try
            {
                student.addCourse((Course) Helper.GetCourses()[i]);
            }
            catch (Exception e) // Handle any exceptions
            {
                // Display error
                lblError.Text = e.Message;
                lblError.Visible = true;
                error = true;
            }
        }

        if (!error)
        {
            // If validation passes, display the results in a table
            DisplayStudentInfo(student, studentType.Text);  
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ValidateForm();
    }

    protected void DisplayStudentInfo(Student student, String type)
    {
        // Output the student's name and type to the page
        lblStudentInfoName.Text = student.Name;
        lblStudentInfoType.Text = student.ToString();

        // Display the success page
        studentInfo.Visible = true;

        // Generate the table header
        var tHead = new TableHeaderRow();
        tblCourses.Rows.Add(tHead);

        var tHeadCellCode = new TableHeaderCell();
        var tHeadCellTitle = new TableHeaderCell();
        var tHeadCellHours = new TableHeaderCell();
        var tHeadCellFee = new TableHeaderCell();

        tHeadCellCode.Text = "Course Code";
        tHeadCellTitle.Text = "Course Title";
        tHeadCellHours.Text = "Weekly Hours";
        tHeadCellFee.Text = "Fee Payable";

        tHead.Cells.Add(tHeadCellCode);
        tHead.Cells.Add(tHeadCellTitle);
        tHead.Cells.Add(tHeadCellHours);
        tHead.Cells.Add(tHeadCellFee);

        // Table generation loop
        foreach (Course course in student.getEnrolledCourses())
        {
            // Start creating the table rows
            var tRow = new TableRow();
            tblCourses.Rows.Add(tRow);

            // Now the table cells
            var tCellCode = new TableCell();
            var tCellTitle = new TableCell();
            var tCellHours = new TableCell();
            var tCellFee = new TableCell();

            tCellCode.Text = course.Code;
            tCellTitle.Text = course.Title;
            tCellHours.Text = Convert.ToString(course.WeeklyHours);
            tCellFee.Text = Convert.ToString(String.Format("{0:C0}", course.Fee));

            tRow.Cells.Add(tCellCode);
            tRow.Cells.Add(tCellTitle);
            tRow.Cells.Add(tCellHours);
            tRow.Cells.Add(tCellFee);
        }

        // Generate the table footer
        var tFoot = new TableRow();
        tblCourses.Rows.Add(tFoot);

        var tFootTotalLabel = new TableCell();
        var tFootTotalRows = new TableCell();
        var tFootTotal = new TableCell();

        tFootTotalLabel.Text = "Total";
        tFootTotalLabel.HorizontalAlign = HorizontalAlign.Right;
        tFootTotalLabel.ColumnSpan = 2;
        tFootTotalRows.Text = Convert.ToString(student.totalWeeklyHours());
        tFootTotal.Text = Convert.ToString(String.Format("{0:C0}", student.feePayable()));

        tFoot.Cells.Add(tFootTotalLabel);
        tFoot.Cells.Add(tFootTotalRows);
        tFoot.Cells.Add(tFootTotal);
    }
}