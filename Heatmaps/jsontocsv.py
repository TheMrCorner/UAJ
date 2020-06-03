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

header = list(jsonDic.keys())
values = list(jsonDic.values())

for i in range(len(header)):   
    aux = [header[i], *values[i]]
    cf.writerow(aux)

co.close()