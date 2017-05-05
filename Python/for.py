#for
names=['Michael','Bob','Tracy']
for name in names:
	print('Hello,%s'%name)

#range
sum=0
for i in range(101):
	sum +=i
print('1+2+....100=%d'%sum)

#while
oddSum=0
end=99
while end>=0:
	oddSum += end
	end=end-2
print('1+3+5+.....99=%d'%oddSum)
