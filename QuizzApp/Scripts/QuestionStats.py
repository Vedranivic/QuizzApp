import clr
clr.AddReference("System.Collections")
from System.Collections.Generic import List, KeyValuePair, Dictionary
clr.AddReference('System.Windows.Forms')
from System.Windows.Forms import *
clr.AddReference('System')
from System import String

def displayQuestionStats(form,model):
    questions = List[model.GetType().GetGenericArguments()[1]]()
    for v in model.Values:
        questions.Add(v)
    mostOftenQ, frequency = findMostOftenQ(questions)
    mostDifficultQ, difficultRate = findMostDifficult(questions)
    easiestQ, easyRate = findEasiest(questions)
    form.Controls[0].Controls[0].Controls["lbMostOften"].Text = "\"" + mostOftenQ + "\""
    form.Controls[0].Controls[0].Controls["label1"].Text = "The most common question (" + str(round(frequency,2))+" % of the times):"
    form.Controls[0].Controls[0].Controls["lbMostDifficult"].Text = "\"" + mostDifficultQ + "\""
    form.Controls[0].Controls[0].Controls["label2"].Text = "Most players get this one wrong (" + str(round(difficultRate,2))+" % of the cases):"
    form.Controls[0].Controls[0].Controls["lbEasiest"].Text = "\"" + easiestQ + "\""
    form.Controls[0].Controls[0].Controls["label3"].Text = "Almost everyone knows this one (" + str(round(easyRate,2))+" % of the cases):"


def findMostOftenQ(questions):
    appearedMax = 0
    total = 0
    mostOftenQ = questions[0]
    for q in questions:
        total += q.appeared
        if(q.appeared > appearedMax):
            appearedMax = q.appeared
            mostOftenQ = q
    return mostOftenQ.text, 100*float(appearedMax)/float(total)

def findMostDifficult(questions):
    incorrectMax = 0.0
    mostDifficultQ = questions[0]
    for q in questions:
        if(q.correctly > 0 or q.incorrectly > 0):
            if(float(q.incorrectly)/float(q.incorrectly+q.correctly) > incorrectMax):
                incorrectMax = float(q.incorrectly)/float(q.incorrectly+q.correctly)
                mostDifficultQ = q
    return mostDifficultQ.text, incorrectMax*100

def findEasiest(questions):
    correctMax = 0.0
    EasiestQ = questions[0]
    for q in questions:
        if(q.correctly > 0 or q.incorrectly > 0):
            if(float(q.correctly)/float(q.incorrectly+q.correctly) > correctMax):
                correctMax = float(q.correctly)/float(q.incorrectly+q.correctly)
                EasiestQ = q
    return EasiestQ.text, correctMax*100
