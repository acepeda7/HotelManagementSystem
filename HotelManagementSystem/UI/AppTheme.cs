using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace HotelManagementSystem.UI;

public static class AppTheme
{
    public static readonly Color Primary = Color.FromArgb(30, 79, 120);
    public static readonly Color PrimaryDark = Color.FromArgb(22, 61, 94);
    public static readonly Color Background = Color.FromArgb(247, 249, 252);
    public static readonly Color Surface = Color.White;
    public static readonly Color Border = Color.FromArgb(218, 225, 232);
    public static readonly Color Text = Color.FromArgb(30, 42, 56);
    public static readonly Color MutedText = Color.FromArgb(91, 107, 124);
    public static readonly Color SelectedRow = Color.FromArgb(224, 239, 252);

    private static readonly Font DefaultFont =
        new("Segoe UI", 10F, FontStyle.Regular);

    public static void Apply(Form form)
    {
        form.BackColor = Background;
        StyleControls(form.Controls);

        // Aplicar al final para que no se sobrescriban estos colores.
        StyleHeader(form);
    }

    private static void StyleHeader(Form form)
    {
        Control[] matches = form.Controls.Find("pnlHeader", true);

        if (matches.Length == 0)
            return;

        Control header = matches[0];
        header.BackColor = PrimaryDark;

        foreach (Control child in header.Controls)
        {
            child.ForeColor = Color.White;

            if (child is Button button)
            {
                button.BackColor = PrimaryDark;
                button.FlatAppearance.BorderColor = Color.White;
            }
        }
    }

    private static void StyleControls(Control.ControlCollection controls)
    {
        foreach (Control control in controls)
        {
            control.ForeColor = Text;

            switch (control)
            {
                case TabPage page:
                    page.BackColor = Background;
                    page.Padding = new Padding(24);
                    break;

                case Panel panel:
                    StylePanel(panel);
                    break;

                case Button button:
                    StyleButton(button);
                    break;

                case DataGridView grid:
                    StyleGrid(grid);
                    break;

                case TextBox textBox:
                    StyleTextBox(textBox);
                    break;

                case ComboBox comboBox:
                    StyleComboBox(comboBox);
                    break;

                case DateTimePicker datePicker:
                    StyleDatePicker(datePicker);
                    break;

                case NumericUpDown numeric:
                    StyleNumericInput(numeric);
                    break;

                case TabControl tabs:
                    StyleTabs(tabs);
                    break;

            }

            if (control.HasChildren)
                StyleControls(control.Controls);
        }
    }

    private static void StylePanel(Panel panel)
    {
        if (panel.Name == "pnlHeader")
        {
            panel.BackColor = PrimaryDark;
            panel.Padding = new Padding(20, 0, 20, 0);

            foreach (Control child in panel.Controls)
                child.ForeColor = Color.White;
        }
        else
        {
            panel.BackColor = Surface;
        }
    }

    private static void StyleButton(Button button)
    {
        button.Cursor = Cursors.Hand;
        button.FlatStyle = FlatStyle.Flat;
        button.Font = new Font("Segoe UI", 9F);
        button.Padding = Padding.Empty;

        bool primaryAction =
            button.Name.Contains("Save", StringComparison.OrdinalIgnoreCase) ||
            button.Name.Contains("Create", StringComparison.OrdinalIgnoreCase) ||
            button.Name.Contains("Confirm", StringComparison.OrdinalIgnoreCase) ||
            button.Name.Contains("Book", StringComparison.OrdinalIgnoreCase) ||
            button.Name.Contains("Search", StringComparison.OrdinalIgnoreCase) ||
            button.Name.Contains("Login", StringComparison.OrdinalIgnoreCase) ||
            button.Name.Contains("Generate", StringComparison.OrdinalIgnoreCase) ||
            button.Name.Contains("Approve", StringComparison.OrdinalIgnoreCase);

        if (primaryAction)
        {
            button.BackColor = Primary;
            button.ForeColor = Color.White;
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseOverBackColor =
                Color.FromArgb(37, 94, 140);
        }
        else
        {
            button.BackColor = Surface;
            button.ForeColor = Primary;
            button.FlatAppearance.BorderColor = Primary;
            button.FlatAppearance.BorderSize = 1;
            button.FlatAppearance.MouseOverBackColor =
                Color.FromArgb(238, 245, 250);
        }
    }

    private static void StyleGrid(DataGridView grid)
    {
        grid.BackgroundColor = Surface;
        grid.BorderStyle = BorderStyle.FixedSingle;
        grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        grid.GridColor = Border;
        grid.RowHeadersVisible = false;
        grid.EnableHeadersVisualStyles = false;
        grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        grid.MultiSelect = false;
        grid.RowTemplate.Height = 42;

        grid.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
        {
            BackColor = Color.FromArgb(237, 243, 248),
            ForeColor = Text,
            Font = new Font("Segoe UI Semibold", 10F),
            SelectionBackColor = Color.FromArgb(237, 243, 248),
            Padding = new Padding(8, 0, 8, 0)
        };

        grid.ColumnHeadersHeight = 42;

        grid.DefaultCellStyle = new DataGridViewCellStyle
        {
            BackColor = Surface,
            ForeColor = Text,
            SelectionBackColor = SelectedRow,
            SelectionForeColor = Text,
            Padding = new Padding(8, 0, 8, 0)
        };

        grid.AlternatingRowsDefaultCellStyle.BackColor =
            Color.FromArgb(250, 251, 253);
    }

    private static void StyleTextBox(TextBox textBox)
    {
        textBox.BorderStyle = BorderStyle.FixedSingle;
        textBox.BackColor = Surface;
        textBox.ForeColor = Text;
    }

    private static void StyleComboBox(ComboBox comboBox)
    {
        comboBox.FlatStyle = FlatStyle.Flat;
        comboBox.BackColor = Surface;
        comboBox.ForeColor = Text;
    }

    private static void StyleDatePicker(DateTimePicker picker)
    {
        picker.CalendarForeColor = Text;
        picker.CalendarMonthBackground = Surface;
    }

    private static void StyleNumericInput(NumericUpDown numeric)
    {
        numeric.BorderStyle = BorderStyle.FixedSingle;
        numeric.BackColor = Surface;
    }

    private static void StyleTabs(TabControl tabs)
    {
        tabs.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
        tabs.SizeMode = TabSizeMode.Normal;
        tabs.Padding = new Point(12, 5);
    }
}
