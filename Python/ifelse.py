a=100
if a>=0:
	print(a)
else:
	print(-a)

# if elif else
age=3
if age>=18:
	print('adult')
elif age>=6:
	print('teenager')
else:
	print('kid')

strYourAge=input("please input your age:")
yourAge=int(strYourAge)
if 	yourAge<=0:
	print('illegal age')			
elif yourAge>=120:
	print('illegal')
else:
	print('your age is :%d' %yourAge)		

#practice 
bmi=80.5/(1.75*1.75)
if bmi<18.5:
	print('过轻')
elif bmi>=18.5 and bmi<=25:
	print('正常')
elif bmi>25 and bmi <=28:
	print('过重')
elif bmi>28 and bmi<=32:
	print('肥胖')
elif bmi>32:
    print('严重肥胖')	