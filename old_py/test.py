kek = [1, 2, 3, 5, 7, 10, 15, 80, 25, 39, 41, 47]


def quicksort(array):
    if len(array) <= 1:
        return array
    limiter = array[len(array) // 2]
    left_nums = [n for n in array if n < limiter]
    middle_nums = [limiter] * array.count(limiter)
    right_nums = [n for n in array if n > limiter]
    return quicksort(left_nums) + middle_nums + quicksort(right_nums)


print(quicksort(kek))