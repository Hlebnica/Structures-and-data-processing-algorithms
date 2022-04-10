from timeit import default_timer as timer
import random


def quick_sort(array):
    if len(array) <= 1:
        return array
    limiter = array[len(array) // 2]
    left = []
    middle = []
    right = []
    for i in array:
        if i < limiter:
            left.append(i)
        elif i == limiter:
            middle.append(i)
        else:
            right.append(i)
    quick_sort(left)
    quick_sort(right)
    return quick_sort(left) + middle + quick_sort(right)


size_list = int(input("Введите размер списка: "))

random_list = []
for i in range(size_list):
    random_list.append(random.randint(0, 500))

now = timer()
quick_sort(random_list)
end = timer()
work = end - now

print(format(work, ".7f"))
print(random_list)
