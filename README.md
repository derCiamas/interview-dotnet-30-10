# Code review: Products API

## Zadanie

Przeprowadź przegląd PR-a zmieniającego endpoint `GET /products/{id:int}`.
Autor twierdzi, że nowa wersja upraszcza obsługę błędów i ujednolica
odpowiedzi API.

Oceń tę argumentację i zdecyduj, czy zmiana nadaje się do połączenia.
Przygotuj komentarze do konkretnych linii, wyjaśnij skutki dla klientów API
i zaproponuj ewentualne poprawki oraz sposób ich weryfikacji.
Oddziel kwestie blokujące od sugestii. Nie musisz zgadzać się z autorem.
Nie łącz PR-a.

Sugerowany czas: 30 minut. Możesz korzystać z dokumentacji i uruchamiać aplikację.

## Uruchomienie

Wymagany jest .NET SDK 10.

```sh
dotnet build
dotnet run --no-build --urls http://127.0.0.1:5080
```

W drugim terminalu:

```sh
curl -i http://127.0.0.1:5080/products/1
curl -i http://127.0.0.1:5080/products/999
```

Serwis zawiera produkty o identyfikatorach `1` i `2`.
Nie wymaga bazy danych ani zewnętrznych usług.
`IProductService` stanowi granicę zależności endpointu; jego implementacja
w tym repozytorium jest celowo prosta.

## Weryfikacja wersji bazowej

Po uruchomieniu aplikacji wykonaj:

```sh
bash scripts/verify-baseline.sh
```

Skrypt opisuje dotychczasowe zachowanie na `main`. Nie zakładaj,
że jego obecny zakres wystarcza do oceny proponowanej zmiany.
Możesz dopisać własne przypadki.
