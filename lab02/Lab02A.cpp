#include <iostream>
#include <list>
#include <vector>
#include <map>
#include <set>
#include <string>
#include <fstream>
#include <algorithm>
#include <functional>

using namespace std;

//lacznie do wykonania sa 3 niezalezne etapy:
//1. operacje na mapach na przykladzie slownika ang-pol (funkcja etap_1()) 2p
//2. sortowanie przez wybor (selectionSort()) 1p
//3. quicksort i generowanie danych testowych (myquicksort() i etap_3()) 1.5+0.5p
//mozesz robic je w dowolnej kolejnosci


void testMapSubsets(map<string, string> polang_subset, map<string, string> angpol_subset, int notPaired)
{
	cout << "notPaired = " << notPaired << endl;

	cout << endl << "Slownik polsko-angielski, podzbior:" << endl;
	for (auto const & kv : polang_subset)
	{
		cout << kv.first << " - " << kv.second << endl;
	}

	cout << endl << "Slownik angielsko-polski, podzbior:" << endl;
	for (auto const & kv : angpol_subset)
	{
		cout << kv.first << " - " << kv.second << endl;
	}
}

void etap_1()
{
	cout << "---ETAP 1---" << endl;
	map<string, string> angpol = {
		{ "derivative", "pochodna" },
		{ "graph", "graf" },
		{ "vertex", "wierzcholek" },
		{ "keyboard", "klawiatura" },
		{ "probability", "prawdopodobienstwo" },
		{ "similar", "podobny" },
		{ "similarity", "podobienstwo" },
		{ "monitor", "monitor" },
		{ "speaker", "glosnik" },
		{ "mathematics", "matematyka" },
		{ "language", "jezyk" }
	}; //zwroc uwage na stworzenie mapy operatorem {}

	string dictionaryPath("pol-ang.txt");
	ifstream dictionaryFile(dictionaryPath, ios::in);

	if (!dictionaryFile)
	{
		cout << "Nie mozna otworzyc pliku " << dictionaryPath << "!" << endl;
		return;
	}

	map<string, string> polang;
	int i = 0;
	string polword, engword;
	while (dictionaryFile >> polword >> engword)
	{
		//wstaw tlumaczenie do polang tak, aby polskie slowo bylo kluczem, a angielskie wartoscia
	}

	map<string, string> polang_subset;
	map<string, string> angpol_subset;
	int notPaired = 0;

	//w tej czesci zadania chodzi o to, aby znalezc sparowane tlumaczenia
	//sparowane tlumaczenie polega na tym, ze w slowniku angpol mamy pare wyrazow angielski-polski,
	//podczas gdy jednoczesnie analogiczna para, polski-angielski, znajduje sie w polang
	//po wykonaniu ponizszej petli w polang_subset i angpol_subset maja byc odpowiednie sparowane tlumaczenia
	//ponadto, w zmiennej notPaired ma sie znalezc liczba rekordow z obu slownikow, ktore nie znalazly swojej pary w drugim slowniku
	//jesli ta petla nie wystarczy Ci, aby obliczyc notPaired, mozesz dopisac jeszcze jedna petle

	for (auto const & kv : angpol)
	{
		//uzupelnianie polang_subset, angpol_subset 
		//obliczanie notPaired
	}
	//obliczanie notPaired c.d.

	testMapSubsets(polang_subset, angpol_subset, notPaired);

	dictionaryFile.close();
}

list<int> selectionSort(const list<int>& input)
{
	// zaimplementuj selection sort na liscie integerow.
	// selection sort:
	// stworz kopie listy wejsciowej, uzywajac iteratorow i konstruktora
	// stworz pusta liste wynikowa
	// n razy wykonaj, gdzie n to rozmiar listy:
	// znajdz najmniejszy element na kopii listy wejsciowej (np. przeiteruj po calej liscie)
	// usun ten element z tej listy (erase())
	// wstaw go na koniec listy wynikowej (push_back())
	//punktacja:
	//za cala dzialajaca funkcje mozna dostac 1p.

	return list<int>();
}

void testSort(list<int> li, list<int> lis)
{
	cout << "lista wejsciowa:" << endl;
	for (auto const & el : li)
	{
		cout << el << ", ";
	}
	cout << endl << "lista posortowana:" << endl;
	for (auto const & el : lis)
	{
		cout << el << ", ";
	}
	cout << endl;
}

void etap_2()
{
	cout << "---ETAP 2---" << endl;

	list<int> list1 = { 5,4,3,2,1 };
	list<int> list1Sorted = selectionSort(list1);
	testSort(list1, list1Sorted);
	list<int> list2 = { 1,2,3,4,5 };
	list<int> list2Sorted = selectionSort(list2);
	testSort(list2, list2Sorted);
	list<int> list3 = { 1, 10,  7,  5,  9,  3,  8,  6,  2,  4 };
	list<int> list3Sorted = selectionSort(list3);
	testSort(list3, list3Sorted);
	list<int> list4 = { 1, 10,  10, 7,  5,  9,  3, 5,  8,  6,  2, 7,  4 };
	list<int> list4Sorted = selectionSort(list4);
	testSort(list4, list4Sorted);
	list<int> list5;
	list<int> list5Sorted = selectionSort(list5);
	testSort(list5, list5Sorted);
}

void myquicksort(vector<int>::iterator lowIterator, vector<int>::iterator highIterator)
{
	// jesli lowIterator wskazuje na wczesniejsza czesc niz highIterator:
	// wywolaj nth_element tak, aby mediana (srodkowa wartosc) byla na srodku
	// wywolaj rekurencyjnie myquicksort na lewym podobszarze (od lowIterator do "srodka")
	// wywolaj rekurencyjnie myquicksort dla prawego podobszaru (od "srodka" do highIterator)
	// punktacja: 
	// 1p za poprawne wywolanie funkcji nth_element
	// 0.5 za poprawny caly quicksort
}

void printVector(string s, vector<int> v)
{
	cout << s << endl;
	for (auto const & el : v)
	{
		cout << el << ", ";
	}
	cout << endl;
}

void etap_3()
{
	cout << "---ETAP 3---" << endl;

	vector<int> vector1 = { 5, 4, 3, 2, 1 };
	printVector("przed posortowaniem:", vector1);
	myquicksort(vector1.begin(), vector1.end());
	printVector("po posortowaniu:", vector1);

	vector<int> vector2 = { 1, 2, 3, 4, 5 };
	printVector("przed posortowaniem:", vector2);
	myquicksort(vector2.begin(), vector2.end());
	printVector("po posortowaniu:", vector2);

	vector<int> vector3 = { 1, 10,  7,  5,  9,  3,  8,  6,  2,  4 };
	printVector("przed posortowaniem:", vector3);
	myquicksort(vector3.begin(), vector3.end());
	printVector("po posortowaniu:", vector3);

	vector<int> vector4 = { 1, 10,  10, 7,  5,  9,  3, 5,  8,  6,  2, 7,  4 };
	printVector("przed posortowaniem:", vector4);
	myquicksort(vector4.begin(), vector4.end());
	printVector("po posortowaniu:", vector4);

	vector<int> vector6;
	printVector("przed posortowaniem:", vector6);
	myquicksort(vector6.begin(), vector6.end());
	printVector("po posortowaniu:", vector6);

	cout << "---random_shuffle---" << endl;
	std::srand(13);
	vector<int> vectorRandom = { 10, 11, 12, 13, 14, 15 }; // w wyniku funkcji random_shuffle i ziarna 13 prawdopodobnie uzyskamy 13, 11, 12, 14, 15, 10
	//
	//wywolanie funkcji random_shuffle
	//
	printVector("przed posortowaniem:", vectorRandom);
	myquicksort(vectorRandom.begin(), vectorRandom.end());
	printVector("po posortowaniu:", vectorRandom);

	// punktacja:
	// po 0.5 za funkcje random_shuffle
}

int main()
{
	etap_1();
	etap_2();
	etap_3();
	return 0;
}