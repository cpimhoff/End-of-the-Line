import requests
import os
import json
from lxml import etree, html
import urllib
import sys

names = open(sys.argv[1])

while True:
    name = names.readline().strip()
    print(name)
    if len(name) == 0:
        break
    if os.path.exists(name + ".jpg"):
        print(" already exists")
        continue
    oldname = name
    name = "+".join(name.split(" "))
    url = "http://www.google.com/search?site=&tbm=isch&source=hp&biw=1366&bih=643&tbm=isch&q=" + name
    headers = {'user-agent': 'Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/49.0.2623.110 Safari/537.36'}
    print(" fetching results...")
    page = requests.get(url, headers=headers).text
    tree = html.fromstring(page)
    results = tree.xpath('//div[@class="rg_meta"]')
    for result in results:
        try:
            print("     trying result...")
            url = json.loads(result.text)["ou"]
            response = urllib.request.urlopen(url)
            newfilename = oldname + ".jpg"
            newfile = open(newfilename, "wb")
            newfile.write(response.read())
            print(" downloaded image")
            break
        except Exception:
            continue
            
