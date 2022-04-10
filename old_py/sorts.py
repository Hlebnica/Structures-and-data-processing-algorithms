def bubble_sort(array):
    for i in range(0, len(array) - 1):
        for j in range(0, len(array) - 1):
            if array[j] > array[j + 1]:
                array[j], array[j + 1] = array[j + 1], array[j]
    return array


def shell_sort(array):
    half_length = len(array) // 2
    while half_length > 0:
        for value in range(half_length, len(array)):
            current_value = array[value]
            position = value
            while position >= half_length and array[position - half_length] > current_value:
                array[position] = array[position - half_length]
                position -= half_length
                array[position] = current_value
        half_length //= 2
    return array


def quick_sort(array):
    if len(array) <= 1:
        return array
    start = array[len(array) // 2]
    left_nums = [n for n in array if n < start]
    middle_nums = [start] * array.count(start)
    right_nums = [n for n in array if n > start]
    return quick_sort(left_nums) + middle_nums + quick_sort(right_nums)


def is_sorted(array):
    if all(array[i] <= array[i + 1] for i in range(len(array) - 1)):
        return True
    return False

