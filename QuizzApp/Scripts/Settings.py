import clr
clr.AddReference("System.Collections")
from System.Collections.Generic import List, KeyValuePair
clr.AddReference('System.Windows.Forms')
from System.Windows.Forms import *
clr.AddReference('System')
from System import String, Object, EventArgs

def displayCategories(form, model):
    categories = getCategories(model)
    comboBox = form.Controls[0].Controls[0].Controls[0].Controls[1]
    comboBox.DataSource = categories
    comboBox.SelectedIndex = comboBox.FindStringExact(form.currentSettings.Category)

def getCategories(model):
    categories = List[String]()
    for v in model.Values:
        if(not categories.Contains(v.category)):
            categories.Add(v.category)
    categories.Add("All")
    categories.Sort()
    return categories

def Hint(form):
    comboBoxType = form.Controls[0].Controls[0].Controls[0].Controls[3]
    comboBoxType.SelectedIndexChanged += showHint
    evarg = EventArgs()
    showHint(comboBoxType,evarg)

def showHint(sender, eventArgs):
    lbHint = sender.Parent.Controls[0]
    if(sender.Text == "Classic"):
        lbHint.Text = "CLASSIC:\r\nPlay a classic game where each finished quiz affects your average score and compete with other players"
    else:
        lbHint.Text = "CASUAL:\r\nPlay a casual game for fun or training (your quiz results don't affect your average score)"
