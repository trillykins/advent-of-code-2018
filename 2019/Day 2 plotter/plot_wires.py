import matplotlib.pylab as plt
from matplotlib.pyplot import figure

x1, y1 = zip(*[(int(a.split(',')[0][3:]), int(a.split(',')[1][2:2+a.split(',')[1][2:].find('}')])) for a in open("wire1.txt", "r").readlines()])
x2, y2 = zip(*[(int(a.split(',')[0][3:]), int(a.split(',')[1][2:2+a.split(',')[1][2:].find('}')])) for a in open("wire2.txt", "r").readlines()])

figure(num=None, figsize=(50, 50), dpi=80, facecolor='w', edgecolor='k')
plt.scatter(x1, y1)
plt.scatter(x2, y2)
plt.show()