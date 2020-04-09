#include <iostream>
#include <vector>
#include <cmath>

using namespace std;

int KOL_VO_(int chislo) //кол-во цифр в числе
{
    int k = 0;
    chislo = abs(chislo);
    while (chislo > 0)
    {
        k++;
        chislo = chislo / 10;
    }
    if (k == 0) k = 1;
    return k;
}
vector<int> IN_VECTOR(int chislo, int n) // перевод положительного числа в вектор
{
    int t;
    vector<int> A;
    for (int i = 0; i <n; i++) { t = chislo % 10; A.insert(A.begin(),t); chislo = chislo / 10; }
    
    return A;
}

int COM_NN_D(int n, vector<int> &A, int m, vector<int> &B)
{

    if (n > m) return 2; else if (m > n) return 1; else if (n == m)
    {
        int i;
        for (i = 0; i < n; i++)
        {
            if (A[i] > B[i]) return 2;
            else if (A[i] < B[i]) return 1;
            else i++;
        }
        if (i == n) return 0;
    }
}
bool NZER_N_B(vector <int> A, int n) // в функцию подаются аргументы (вектор числа, размерность числа)
{
    for (int i = 0; i < n; i++) { // проверка каждого элемента вектора (числа)
        if (A[i] != 0) { // если хотя бы один элемент не равен 0
            return 0; // вывести 0 (нет)
        }
    } // в противном случае
    return 1; // вывести 1 (да)
}
void ADD_1N_N(int& n, vector <int>& A)
{
    bool desatok = 1; int n2 = n - 1;
    for (n2; n2 >= 0; n2--)
    {
        if (desatok)
        {
            ++A[n2];
            desatok = 0;
            if (A[n2] == 10)
            {
                A[n2] = 0;
                desatok = 1;
            }
        }
    }
    if (desatok)
    {
        A[0] = 0;
        n++;
        A.insert(A.begin(), 1);
    }
}
vector <int> ADD_NN_N(vector <int> A, int n, vector <int> B, int m)
{
    int desatok = 0; vector <int> C;
    if (n > m)
    {
        for (int i = 0; i < n - m; i++) B.insert(B.begin(), 0);
    }
    else if (m > n)
    {
        for (int i = 0; i < m - n; i++) A.insert(A.begin(), 0);

    }
    for (int i = n - 1; i >= 0; i--)
    {
        int sum = A[i] + B[i] + desatok;
        C.insert(C.begin(), sum % 10);
        desatok = sum / 10;
    }
    if (desatok != 0)
    {
        C.insert(C.begin(), desatok);
    }
    return C;
}
void MUL_ND_N(int& n, vector <int>& A, int k)
{
    int desatok = 0; int n2 = n - 1; int t;
    for (n2; n2 >= 0; n2--)
    {
        t = A[n2];
        A[n2] = ((A[n2] * k) + desatok) % 10;
        desatok = ((t * k) + desatok) / 10;
    }
    if (desatok != 0)
    {
        A.insert(A.begin(), desatok);
        n++;
    }
}
void MUL_Nk_N(int& n, vector <int>& A, int k)
{
    for (int i = 0; i < k; i++)
    {
        A.insert(A.end(), 0);
        n++;
    }
}
vector<int> ABS_Z_N(int chislo, int n, int &b)
{ 
    if (chislo >= 0) b = 0; else b = 1;
    chislo = abs(chislo);
    vector<int> A = IN_VECTOR(chislo, n);
    return A;
}
int POZ_Z_D(bool b, int n, vector <int> A)
{
    bool flaq = 0;
    if (b == 1) return 1;
    if (b == 0)
    {
        for (int i = 0; i < n; i++)
        {
            if (A[i] != 0) flaq = 1;
        }
        if (flaq == 0) return 0; else return 2;
    }
}
void MUL_ZM_Z(int &b) 
{
    b = -b;
}
void TRANS_N_Z(unsigned int natur, int b, int n, vector<int>& A)
{
    int buffer, pomosh, i;
    b = 0;
    vector<int> A1 = IN_VECTOR(natur, n);
    /*while (natur > 0)
    {
        n++;
        buffer = natur % 10;
        A.push_back(buffer);
        natur /= 10;
    }*/
    for (i = 0; i < n / 2; i++)
    {
        pomosh = A1[i];
        A1[i] = A1[n - i - 1];
        A1[n - i - 1] = pomosh;
    }
}
void TRANS_Z_N(int b, int n, vector<int>& A) //  есть перевод в число
{
    unsigned int natur = 0;
    int i;
    for (i = 0; i < n; i++)
    {
        natur += A[i];
        if (i + 1 < n)
            natur *= 10;
    }
}
bool INT_Q_B(int chislitel, unsigned int znamenatel)
{
    chislitel = abs(chislitel);
    int drob1 = chislitel / znamenatel;
    double chislitel2 = chislitel;
    double drob2 = chislitel2 / znamenatel;
    if (drob2 - drob1 == 0)
        return 1; else return 0;
}
void TRANS_Z_Q(int chislitel, int celoe, unsigned int znamenatel)
{
    chislitel = celoe;
    znamenatel = 1;
}
void TRANS_Q_Z(int chislitel,int celoe, unsigned int znamenatel)
{
    if (chislitel % znamenatel == 0) celoe = chislitel / znamenatel;
    else cout<< "error";
}
void MUL_Pxk_P(int m, int k, vector<int> A1)
{
    int i;
    for (i = m; i >= 0; i--)
    {
        A1[i + k] = A1[i];
        A1[i] = 0;
    }
    for (i = m + k; i >= 0; i--)
    {
        if (i > 0)
            cout << A1[i]<< "x^" << i << "+";
        else
            cout << A1[i] << endl;
    }
}
void LED_P_Q(int m, vector <int>C) 
{
    cout << C[m];
}
int DEG_P_N(int m, vector <int>C)
{
    return m;
}
void DER_P_P(int m, vector <int>C)
{
    int i;
    cout<< "Вы ввели многочлен: ";
    for (i = m; i >= 0; i--)
        if (i > 0)
            cout<< C[i] << "x^" << i << "+";
        else
            cout << C[i] << endl;
    cout << "Производная многочлена: ";
    for (i = 0; i <= m - 1; i++)
    {
        C[i] = C[i + 1] * (i + 1);
    }
    C[m] = 0;
    for (i = m - 1; i >= 0; i--)
        if (i > 0)
            cout << C[i] << "x^" << i << "+";
        else
            cout << C[i] << endl;
}
vector <int> ADD_NN_N(vector <int> A, int n, vector <int> B, int m)
{
int desatok = 0; vector <int> C;
if (n > m)
{
for (int i = 0; i < n - m; i++) B.insert(B.begin(), 0);
}
else if (m > n)
{
for (int i = 0; i < m - n; i++) A.insert(A.begin(), 0);

}
for (int i = n - 1; i >= 0; i--)
{
int sum = A[i] + B[i] + desatok;
C.insert(C.begin(), sum % 10);
desatok = sum / 10;
}
if (desatok != 0)
{
C.insert(C.begin(), desatok);
}
return C;
}


//int SUB_NN_N(int SizeA, int SizeB, vector<int> A, vector<int> B) // почти идеальный блок

int main()
{
    int chislo, chislo2, n, m,b,b1;
   // int m,k, buffer, chislo;
    cin >> chislo>>chislo2;
    n = KOL_VO_(chislo);
    m = KOL_VO_(chislo2);
    vector<int> A;
    vector<int> B;
    vector<int> A = ABS_Z_N(chislo, n, b);
    vector<int> B = ABS_Z_N(chislo2, m, b1);
    vector <int> C = ADD_NN_N(A, n, B, m);
   // int  chislo, b,chislitel, znamenatel, m,k;
   // cin >> chislo;
    //int n = KOL_VO_(chislo);
    //vector<int> A1 = ABS_Z_N(chislo, n, b);
   // TRANS_Z_N(b, n, A);
   //cin >> m;
   //cin >> k;
  //  int t;
   // cin >> chislo;
  //  vector<int> C;
   
  /* for (int i = m; i >= 0; i--)
    {
        {   
            buffer = chislo % 10;
            C.push_back(buffer);
            chislo /= 10;
        }
           // cin >> t;
          //  C.insert(C.begin(), t);
    }*/
    //DER_P_P(m, C);
   //LED_P_Q(m, C);
   //cout<< DEG_P_N(m, C);
   // C.resize(m + k + 1);
  // MUL_Pxk_P(m, k, C);  
    //SUB_NN_N(n, m, A, B);
    //vector<int> A = IN_VECTOR(chislo,n);
   //for (int i = m; i >=0; i--) cout << C[i];
   // vector<int> A = ABS_Z_N(chislo, n, b);
    for (int i = 0; i < n; i++) cout << С[i];
   // cout << endl<<  b;
   /* vector<int> A;
    vector<int> B;
    int c = COM_NN_D(n, A, m, B);
    cout << c;
   // int n, m, buffer;
   // vector<int> A;*/

}

