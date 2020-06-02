import pandas as pd
import json
import csv


f = open(r'30052020_0.json')
df = json.load(f)


cf = csv.writer(open("test.csv", "wb+"))

# Write CSV Header, If you dont need that, remove this line
cf.writerow(["TimeSinceStart"])

for df in df:
    cf.writerow([df["TimeSinceStart"]])