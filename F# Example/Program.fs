// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open System
open System.Drawing
open System.Windows.Forms
open System.Runtime.InteropServices
open Microsoft.CSharp
open Microsoft.VisualBasic

[<DllImport("kernel32.dll")>] extern System.IntPtr GetConsoleWindow()
[<DllImport("user32.dll")>] extern bool ShowWindow(System.IntPtr, int)

let close = GetConsoleWindow()
ShowWindow(close, 0) |> ignore

let mainform = new Form(Text="Example", Visible=true, Width= 1000, Height = 650)
mainform.FormBorderStyle <- FormBorderStyle.FixedToolWindow

let frmmsgboxbtn = new Button()
frmmsgboxbtn.Text <- "Click"
frmmsgboxbtn.Location <- new Point(450,250)
frmmsgboxbtn.Size <- new Size(100,25)
mainform.Controls.Add(frmmsgboxbtn)

let labeldescribe = new Label()
labeldescribe.Text <- "Your Message:"
labeldescribe.Location <- new Point(400,300)
mainform.Controls.Add(labeldescribe)

let textbox1 = new TextBox()
textbox1.Location <- new Point(450,225)
mainform.Controls.Add(textbox1)

let labeltext = new Label()
labeltext.Location <- new Point(500,300)
mainform.Controls.Add(labeltext)

let btn1Click click = 
          labeltext.Text <- textbox1.Text
          MessageBox.Show(textbox1.Text,"Test") |> ignore
          

let Click = frmmsgboxbtn.Click.Add(btn1Click)

[<STAThread>]
Application.Run(mainform)


[<EntryPoint>]

let main argv = 
    printfn "%A" argv
    0 // return an integer exit code
