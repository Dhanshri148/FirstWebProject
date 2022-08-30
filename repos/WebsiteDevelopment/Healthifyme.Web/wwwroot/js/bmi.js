<script runat="server"> 
public string bmiStyle = "alert alert-primary";
            protected void Page_Load(object sender, System.EventArgs e)
{
    if (!this.IsPostBack) {
    }
}

            protected void Button1_Click(object sender, System.EventArgs e)
{

        double index = 0;

    if (height.Text != "" && weight.Text != "") {
                    double h = Convert.ToInt32(height.Text);
                    double w = Convert.ToInt32(weight.Text);
        index = Math.Round(w / (h * h) * 703, 2);
    }

    if (index < 18.5) {
        result.Text = "underweight - BMI : " + index;
        bmiStyle = "alert alert-secondary";
    }
    else if (index < 25) {
        result.Text = "normal - BMI : " + index;
        bmiStyle = "alert alert-success";
    }
    else if (index < 30) {
        result.Text = "overweight - BMI : " + index;
        bmiStyle = "alert alert-warning";
    }
    else {
        result.Text = "obese - BMI : " + index;
        bmiStyle = "alert alert-danger";
    }
}

</script>