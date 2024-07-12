using PersonalServerManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace PersonalServerManager
{
    /// <summary>
    /// Interaction logic for ServerDetailsWindow.xaml
    /// </summary>
    public partial class ServerDetailsWindow : Window
    {
        private bool isSyntaxHighlightingInProgress = false;

        public ServerDetailsWindow(ServerDetailsViewModel serverDetails)
        {
            InitializeComponent();

            DataContext = serverDetails;
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            // Update the selected item in the view model
            if (DataContext is ServerDetailsViewModel viewModel)
            {
                viewModel.FileSystem.SelectedItem = e.NewValue as FileSystemItem;
            }
        }


        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Update the selected item in the view model
            //if (DataContext is ServerDetailsViewModel viewModel && viewModel.Scripts.SelectedScript != null)
            //{
            //    //richTextBox.Document.Blocks.Clear();
            //    //richTextBox.Document.Blocks.Add(new Paragraph(new Run(viewModel.Scripts.SelectedScript.Content)));
            //    //TextBox_TextChanged(richTextBox, null);
            //}
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!isSyntaxHighlightingInProgress)
            {
                isSyntaxHighlightingInProgress = true;
                ApplySyntaxHighlighting((RichTextBox)sender);
                isSyntaxHighlightingInProgress = false;
            }
        }

        //private string GetRichTextBoxText()
        //{
        //    TextRange textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
        //    return textRange.Text;
        //}

        //private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    ApplySyntaxHighlighting((RichTextBox)sender);
        //}
        private void ApplySyntaxHighlighting(RichTextBox richTextBox)
        {
            string[] keywords = { "if", "else", "for", "while" };
            string[] operators = { "+", "-", "*", "/" };
            string[] types = { "int", "float", "string", "bool" };

            richTextBox.Document.Blocks.Clear();

            //TextRange textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
            //string text = textRange.Text;

            var viewModel = DataContext as ServerDetailsViewModel;

            string text = viewModel != null && viewModel.Scripts?.SelectedScript != null
            ? viewModel.Scripts?.SelectedScript?.Content
            : "";


            //viewModel.Scripts?.SelectedScript?.Content;

            Paragraph paragraph = new Paragraph();
            paragraph.FontFamily = new FontFamily("Consolas");
            paragraph.FontSize = 12;

            int currentPosition = 0;

            while (currentPosition < text.Length)
            {
                string word = GetNextWord(text, currentPosition);
                bool highlighted = false;

                foreach (string keyword in keywords)
                {
                    if (word == keyword)
                    {
                        highlighted = true;
                        break;
                    }
                }

                if (!highlighted)
                {
                    foreach (string op in operators)
                    {
                        if (word == op)
                        {
                            highlighted = true;
                            break;
                        }
                    }
                }

                if (!highlighted)
                {
                    foreach (string type in types)
                    {
                        if (word == type)
                        {
                            highlighted = true;
                            break;
                        }
                    }
                }

                if (highlighted)
                {
                    Run run = new Run(word);
                    run.Foreground = Brushes.Blue; // Change color based on type
                    paragraph.Inlines.Add(run);
                }
                else
                {
                    Run run = new Run(word);
                    paragraph.Inlines.Add(run);
                }

                currentPosition += word.Length;
            }

            richTextBox.Document.Blocks.Add(paragraph);
        }


        //private string GetNextWord(string text, int startPosition)
        //{
        //    int index = startPosition;
        //    while (index < text.Length && !char.IsWhiteSpace(text[index]))
        //    {
        //        index++;
        //    }

        //    return text.Substring(startPosition, index - startPosition);
        //}

        private string GetNextWord(string text, int startPosition)
        {
            StringBuilder wordBuilder = new StringBuilder();

            int index = startPosition;

            // Skip leading whitespace
            while (index < text.Length && char.IsWhiteSpace(text[index]))
            {
                index++;
            }

            // Build the word character by character until a whitespace or end of string is encountered
            while (index < text.Length && !char.IsWhiteSpace(text[index]))
            {
                wordBuilder.Append(text[index]);
                index++;
            }

            return wordBuilder.ToString();
        }


        //private void ApplySyntaxHighlighting(RichTextBox richTextBox)
        //{
        //    string[] keywords = { "if", "else", "for", "while" };
        //    string[] operators = { "+", "-", "*", "/" };
        //    string[] types = { "int", "float", "string", "bool" };

        //    richTextBox.Document.Blocks.Clear();

        //    TextRange textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
        //    string text = textRange.Text;

        //    Paragraph paragraph = new Paragraph();
        //    paragraph.FontFamily = new FontFamily("Consolas");
        //    paragraph.FontSize = 12;

        //    int currentPosition = 0;

        //    while (currentPosition < text.Length)
        //    {
        //        string word = GetNextWord(text, currentPosition);
        //        bool highlighted = false;

        //        foreach (string keyword in keywords)
        //        {
        //            if (word == keyword)
        //            {
        //                highlighted = true;
        //                break;
        //            }
        //        }

        //        if (highlighted)
        //        {
        //            Run run = new Run(word);
        //            run.Foreground = Brushes.Blue;
        //            paragraph.Inlines.Add(run);
        //        }
        //        else
        //        {
        //            Run run = new Run(word);
        //            paragraph.Inlines.Add(run);
        //        }

        //        currentPosition += word.Length;
        //    }

        //    richTextBox.Document.Blocks.Add(paragraph);
        //}








        //private void ApplySyntaxHighlighting(RichTextBox richTextBox)
        //{
        //    string[] keywords = { "if", "else", "for", "while" };
        //    string[] operators = { "+", "-", "*", "/" };
        //    string[] types = { "int", "float", "string", "bool" };

        //    richTextBox.Document.Blocks.Clear();

        //    Paragraph paragraph = new Paragraph();
        //    paragraph.FontFamily = new FontFamily("Consolas");
        //    paragraph.FontSize = 12;

        //    string text = richTextBox.Text;
        //    int currentPosition = 0;

        //    while (currentPosition < text.Length)
        //    {
        //        string word = GetNextWord(text, currentPosition);
        //        bool highlighted = false;

        //        foreach (string keyword in keywords)
        //        {
        //            if (word == keyword)
        //            {
        //                highlighted = true;
        //                break;
        //            }
        //        }

        //        if (highlighted)
        //        {
        //            Run run = new Run(word);
        //            run.Foreground = Brushes.Blue;
        //            paragraph.Inlines.Add(run);
        //        }
        //        else
        //        {
        //            Run run = new Run(word);
        //            paragraph.Inlines.Add(run);
        //        }

        //        currentPosition += word.Length;
        //    }

        //    richTextBox.Document.Blocks.Add(paragraph);
        //}

        //private string GetNextWord(string text, int startPosition)
        //{
        //    int index = startPosition;
        //    while (index < text.Length && !char.IsWhiteSpace(text[index]))
        //    {
        //        index++;
        //    }

        //    return text.Substring(startPosition, index - startPosition);
        //}


















        //// Apply syntax highlighting when text changes
        //private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    ApplySyntaxHighlighting((TextBox)sender);
        //}


        //// Define syntax highlighting rules and apply to the text
        //private void ApplySyntaxHighlighting(TextBox textBox)
        //{
        //    string[] keywords = { "if", "else", "for", "while" };
        //    string[] operators = { "+", "-", "*", "/" };
        //    string[] types = { "int", "float", "string", "bool" };

        //    // Clear previous formatting
        //    textBox.SelectAll();
        //    textBox.SelectionBrush = Brushes.Transparent;
        //    textBox.SelectionColor = Colors.Black;

        //    // Apply highlighting rules
        //    foreach (string keyword in keywords)
        //    {
        //        ApplyHighlighting(textBox, keyword, Colors.Blue);
        //    }

        //    foreach (string op in operators)
        //    {
        //        ApplyHighlighting(textBox, op, Colors.Red);
        //    }

        //    foreach (string type in types)
        //    {
        //        ApplyHighlighting(textBox, type, Colors.DarkOrange);
        //    }
        //}

        //// Helper method to apply highlighting to text
        //private void ApplyHighlighting(TextBox textBox, string word, Color color)
        //{
        //    int index = textBox.Text.IndexOf(word);
        //    while (index != -1)
        //    {
        //        textBox.Select(index, word.Length);
        //        textBox.SelectionBrush = new SolidColorBrush(color);
        //        textBox.SelectionColor = color;
        //        index = textBox.Text.IndexOf(word, index + word.Length);
        //    }
        //}
    }
}
