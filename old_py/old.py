from sorts import bubble_sort, shell_sort, quick_sort, is_sorted
from timeit import default_timer as timer
import random
from prettytable import PrettyTable


def time_counter(sort, array):
    time_now = timer()
    sort(array)
    end_time = timer()
    working_time = end_time - time_now
    return format(working_time, ".7f")


def time_counter_for_inner(array):
    time_now = timer()
    array.sort()
    end_time = timer()
    working_time = end_time - time_now
    return format(working_time, ".7f")


def print_sort_check(sort_method, sort_name):
    print(
        f"Список отсортирован методом {sort_name}?:", is_sorted(sort_method(sort_list.copy())),
        f"\nСлучайный список отсортирован методом {sort_name}?: ", is_sorted(sort_method(random_list.copy())),
        f"\nСписок в обратном порядке отсортирован методом {sort_name}?: ",
        is_sorted(sort_method(sort_list_reversed.copy())), "\n"
    )


def print_sort_check_for_inner(sort_name):
    sort_list.sort()
    random_list.sort()
    sort_list_reversed.sort()
    print(
        f"Список отсортирован методом {sort_name}?:", is_sorted(sort_list),
        f"\nСлучайный список отсортирован методом {sort_name}?: ", is_sorted(random_list),
        f"\nСписок в обратном порядке отсортирован методом {sort_name}?: ", is_sorted(sort_list_reversed), "\n"
    )


size_list = int(input("Введите размер списка: "))

sort_list = []
for i in range(size_list):
    sort_list.append(i)

random_list = []
for i in range(size_list):
    random_list.append(random.randint(0, 500))

sort_list_reversed = []
for i in sort_list[::-1]:
    sort_list_reversed.append(i)

print("Список отсортирован?: ", is_sorted(sort_list),
      "\nСлучайный список отсортирован?: ", is_sorted(random_list),
      "\nСписок в обратном порядке отсортирован?: ", is_sorted(sort_list_reversed), "\n")

sorts_times = PrettyTable()
sorts_times.field_names = ["Метод", "Сортированный", "Случайный", "Сортированный в обратном порядке"]
sorts_times.add_row(["Пузырьковая", time_counter(bubble_sort, sort_list.copy()),
                     time_counter(bubble_sort, random_list.copy()),
                     time_counter(bubble_sort, sort_list_reversed.copy())])

sorts_times.add_row(["Метод Шелла", time_counter(shell_sort, sort_list.copy()),
                     time_counter(shell_sort, random_list.copy()),
                     time_counter(shell_sort, sort_list_reversed.copy())])

sorts_times.add_row(["Быстрая", time_counter(quick_sort, sort_list.copy()),
                     time_counter(quick_sort, random_list.copy()),
                     time_counter(quick_sort, sort_list_reversed.copy())])

sorts_times.add_row(["Встроенная", time_counter_for_inner(sort_list.copy()),
                     time_counter_for_inner(random_list.copy()),
                     time_counter_for_inner(sort_list_reversed.copy())])

with open("output.txt", "w", encoding="utf-8") as file:
    file.write(str(sorts_times))

print_sort_check(bubble_sort, "Пузырьковый")
print_sort_check(shell_sort, "Метод Шелла")
print_sort_check(bubble_sort, "Быстрый")
print_sort_check_for_inner("Встроенная")
