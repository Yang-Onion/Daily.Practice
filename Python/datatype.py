#整数
print(1,100,-100,0)
#十六进制数
print(0xff00,0xa5b4c3d2)
#浮点数,科学计数法
print(1.01,1.03e10,1.2e-5)
#字符串
print('Hello')
print("Hello,World")
print("I'm Tom")
print('I\'m Tome')
print('she said "Yes"')
#\转义
print("she said \"Yes\"")
#\n换行
print('she said \n \'Yes\'')
#\t空格
print('I\'m learning a new language:\t python')
# '''内容''' 多行
print('''hi~1
hi~2
hi~3 ''')
print(r'''a
   b
   c
d''')
#布尔值
print(3>2)
print(not True)
#
print(10/3)
print(9/3)
print(10//3)
print(10%3)

#字符串
a=ord('中')
print(a)
b=chr(25991)
print(b)
c= '\u4e2d\u6587'
print(c)

#list
list=['Tom','Lucy','Lily']
print(list[-2])
list.insert(1,'Hanmeimei')
print(list)
list.pop(3)
print(list)

list2=['Hello',['Python','.net core'],12.10,True]
print(list2[1][0])
list2.insert(2,list)
print(list2)

#tuple
t=(1,2,['A','AA'])
print(t)
print(t[2][1])

L = [
    ['Apple', 'Google', 'Microsoft'],
    ['Java', 'Python', 'Ruby', 'PHP'],
    ['Adam', 'Bart', 'Lisa']
]
print(L[0][0])
print(L[1][1])
print(L[2][2])
