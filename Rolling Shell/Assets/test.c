#include <stdio.h>
#include <stdbool.h>

int *P_identite(int n) {
    if (n < 0) return NULL; // on rend null ou on dit erreur ?
    int *P = (int *)malloc(n * sizeof(int));
    for (int i = 0; i < n; ++i) P[i] = i;
    return P;
}


int *P_inverse(const int *P, int n) {
    if ( P == NULL || n < 0) return NULL; // pareil, est-ce qu'on doit vérifier ?
    int *inv = (int *)malloc(n * sizeof(int));
    for (int i = 0; i < n; ++i) inv[P[i]] = i;
    return inv;
}


void P_compose_to(const int *P, const int *Q, int *R, int n) {
    if (P==NULL || Q==NULL || R==NULL || n < 0) return;
    for (int i = 0; i < n; ++i)  R[i] = P[Q[i]]; // Il y a pas mal de cas problématiques : On fait quoi si  P[Q[i]] > n par exemple ?
}

bool P_verife(const int *P, int n) {
    if (P == NULL || n <= 0) //  le <= est là pour accepter la bijection sur l'ensemble vide
        return true;
    for (int i = 0; i < n; ++i) {
        int v = P[i];
        if (v < 0 || v >= n)
            return false;  // valeurs pas dans l'inervalle
        for (int j = i + 1; j < n; ++j) { // on vérifie que v n'apparait pas ailleurs 
            if (P[j] == v)
                return false;
        }
    }
    return true;
}


