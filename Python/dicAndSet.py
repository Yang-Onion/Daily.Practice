dic={'Michael':95,'Bob':80,'Tracy':60}
print(dic['Bob'])

print(dic['Tracy'])
dic['Tracy']=100
print(dic['Tracy'])

for d in dic:
	print('%s:%d'%d,%dic[d])
	print(dic[d])