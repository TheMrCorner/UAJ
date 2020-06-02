import json
import csv

eventTypes =["ChangeState", "Damaged", "EnemyDeath", "PlayerDeath", "PlayerShoots", "InitLevel", "EndLevel"]
filename = "Data/30052020/30052020_0.json"

with open(filename, 'r', encoding='utf-8') as f:
    jsonFile = json.load(f)

jsonDic = {}
num = range(len(jsonFile)) 
for t in range(len(jsonFile)):
    name = jsonFile[t]
    name = list(name.keys())[0]
    if name not in jsonDic:
        jsonDic[name] = []
    jsonFile[t][name]["Position"]
    jsonDic[name].append(jsonFile[t][name]["Position"])


co = open("test.csv", "w")
cf = csv.writer(co)

header = jsonDic.keys()
values = list(jsonDic.values())

cf.writerow(header)
for v in values:      
      cf.writerow(v)
co.close()