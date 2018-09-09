import clr
clr.AddReference("System.Collections")
from System.Collections.Generic import List

def updatePlayerStats(profile,game):
    numberOfGames = profile.Games.Count
    totalScore = profile.AverageScore*numberOfGames
    totalScore = totalScore + game.Result.getScore()
    numberOfGames = numberOfGames + 1
    newAverageScore = totalScore/numberOfGames
    profile.AverageScore = newAverageScore
    profile.Games.Add(game)
