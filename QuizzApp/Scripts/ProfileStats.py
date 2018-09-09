import clr
clr.AddReference("System.Collections")
from System.Collections.Generic import List, KeyValuePair
clr.AddReference('System.Windows.Forms')
from System.Windows.Forms import *
clr.AddReference('System')
from System import String

def displayBasicStats(form, profile, model):
    form.Controls[0].Controls[0].Controls["tbFullName"].Text = profile.DisplayName
    form.Controls[0].Controls[0].Controls["tbEmail"].Text = profile.Email
    form.Controls[0].Controls[0].Controls[2].Controls["lbGames"].Text = str(profile.getNumberOfGames())
    form.Controls[0].Controls[0].Controls[2].Controls["lbAverage"].Text = str(round(profile.AverageScore,2))+" %"
    form.Controls[0].Controls[0].Controls[2].Controls[2].Controls["lbRank"].Text = str(calculateRank(profile,model))+'.'
    bestCategory, bestCategoryScore = findBestCategory(profile)
    worstCategory, worstCategoryScore = findWorstCategory(profile)
    if(bestCategory!="-"):
        form.Controls[0].Controls[0].Controls[2].Controls["lbBestin"].Text = str(bestCategory) + "\r\n(" + str(round(bestCategoryScore,2)) + " %)"
    else:
        form.Controls[0].Controls[0].Controls[2].Controls["lbBestin"].Text = "-/-"
    if(worstCategory!="-"):
        form.Controls[0].Controls[0].Controls[2].Controls["lbWorstin"].Text = str(worstCategory) + "\r\n(" + str(round(worstCategoryScore,2)) + " %)"
    else:
        form.Controls[0].Controls[0].Controls[2].Controls["lbWorstin"].Text = "-/-"

def calculateRank(profile,model):
    profiles = List[profile.GetType()]()
    for v in model.Values:
        profiles.Add(v) 
    profilesSorted = sorted(profiles, key=lambda p:p.AverageScore, reverse=True)
    for p in profilesSorted:
        if (p.Email == profile.Email): return profilesSorted.index(p)+1

def findBestCategory(profile):
    if(profile.getNumberOfGames()!=0):
        bestCategory = profile.Games[0].Category
        categories = List[String]()
        for game in profile.Games:
            if(not categories.Contains(game.Category)):
                categories.Add(game.Category)  
        bestScore = 0
        for c in categories:
            score = 0
            counter = 0
            for g in profile.Games:
                if(g.Category == c):
                    score = score + g.Result.getScore()
                    counter = counter + 1
            if(score/counter > bestScore):
                bestScore = score/counter
                bestCategory = c
        return bestCategory, bestScore
    else: return "-", 0.0

def findWorstCategory(profile):
    if(profile.getNumberOfGames()!=0):
        worstCategory = profile.Games[0].Category
        categories = List[String]()
        for game in profile.Games:
            if(not categories.Contains(game.Category)):
                categories.Add(game.Category)  
        worstScore = 999999999
        for c in categories:
            score = 0
            counter = 0
            for g in profile.Games:
                if(g.Category == c):
                    score = score + g.Result.getScore()
                    counter = counter + 1
            if(score/counter < worstScore):
                worstScore = score/counter
                worstCategory = c
        return worstCategory, worstScore
    else: return "-", 0.0
