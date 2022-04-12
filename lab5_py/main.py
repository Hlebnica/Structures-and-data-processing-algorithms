from timeit import default_timer as timer
from prettytable import PrettyTable


# - Отсортировать одномерный массив целых чисел по убыванию.
#   Сортировки: простым включением и пузырькая
# - неотсортированной, частично отсортированной и отсортированную в обратном порядке
# - сравнение эффективности методов сортировки


def time_counter(sort, array):  # Подсчет времени работы
    time_now = timer()
    sort(array)
    end_time = timer()
    working_time = end_time - time_now
    return format(working_time, ".7f")


def bubble_sort(array):  # Пузырьковая сортировка
    for i in range(0, len(array) - 1):
        for j in range(0, len(array) - 1):
            if array[j] < array[j + 1]:  # смена условия, чтобы был обратный ход
                array[j], array[j + 1] = array[j + 1], array[j]
    return array


def insertion(array):  # Сортировка простыми включениями
    for i in range(len(array)):
        j = i - 1
        key = array[i]
        while array[j] < key and j >= 0:  # смена условия, чтобы был обратный ход
            array[j + 1] = array[j]
            j -= 1
        array[j + 1] = key
    return array


if __name__ == '__main__':
    size_list = int(input("Введите размер списка: "))

    sort_list = []  # Сортированный в обратном порядке
    for i in range(size_list):
        sort_list.append(i)

    sort_list_half = []  # Сортированный на половину
    for i in sort_list[:(size_list // 2) - 1:-1]:
        sort_list_half.append(i)
    for i in sort_list[:size_list // 2]:
        sort_list_half.append(i)

    sort_list_reversed = []  # Сортированный список
    for i in sort_list[::-1]:
        sort_list_reversed.append(i)

    print("Сортированный список ", sort_list_reversed)
    print("Сортированный в обратном порядке ", sort_list)
    print("Сортированный на половину", sort_list_half)

    sorts_times = PrettyTable()
    sorts_times.field_names = ["Метод", "Сортированный", "Сортированный в обратном порядке", "Сортированный на половину"]
    sorts_times.add_row(["Пузырьковая", time_counter(bubble_sort, sort_list_reversed.copy()),
                         time_counter(bubble_sort, sort_list.copy()),
                         time_counter(bubble_sort, sort_list_half.copy())])
    sorts_times.add_row(["Простыми включениями", time_counter(insertion, sort_list_reversed.copy()),
                         time_counter(insertion, sort_list.copy()),
                         time_counter(insertion, sort_list_half.copy())])

    print(sorts_times)
