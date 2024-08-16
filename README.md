# 2D-fotbal-unity

## PlayerMovement.cs
Proměnné:
- `moveSpeed`: Rychlost pohybu hráče.
- `jumpForce`: Síla, kterou hráč vyskočí.
- `playerPrefix`: Řetězec, který určuje ovládací prefix pro vstupy hráče (např. pro více hráčů).

Komponenty:
- `rb`: Odkaz na komponentu Rigidbody2D, která se stará o fyzikální vlastnosti hráče.
- `isGrounded`: Určuje, zda je hráč na zemi (potřebné pro kontrolu skákání).

Funkce `Start()`:
- Na začátku hry skript získá referenci na komponentu Rigidbody2D připojenou k hernímu objektu.

Funkce `Update()`:
- Získává horizontální vstup (např. pohyb vlevo a vpravo) pomocí `Input.GetAxis()`, a podle toho nastaví rychlost hráče.
- Pokud hráč stiskne tlačítko pro skok (`Jump`) a je na zemi (`isGrounded`), přidá na hráče sílu směrem nahoru, což způsobí skok. Následně je nastaveno, že hráč již není na zemi.

Funkce `OnCollisionEnter2D()`:
- Když hráč narazí na objekt označený tagem "Ground", nastaví se proměnná `isGrounded` na `true`, což umožní hráči znovu skočit.

Skript zajišťuje základní horizontální pohyb a skákání hráče na základě vstupů z klávesnice.

## BallController.cs
Proměnné:
- `maxVelocity`: Maximální rychlost míče.
- `goalSound` a `bounceSound`: Zvuky pro gól a odraz.
- `resetPosition`: Pozice, kam se míč vrátí po vstřelení gólu.

Komponenty:
- `rb`: Fyzika míče (`Rigidbody2D`).
- `audioSource`: Pro přehrávání zvuků.

Funkce `Start()`:
- Inicializuje fyziku a zvuky.
- Nastaví výchozí pozici resetu, pokud není definována.

Funkce `Update()`:
- Omezí rychlost míče na maximální hodnotu.

Funkce `OnCollisionEnter2D()`:
- Při nárazu na hráče nebo zem přehraje odrazový zvuk.

Funkce `OnTriggerEnter2D()`:
- Když míč vstřelí gól, přehraje zvuk, resetuje pozici míče a aktualizuje skóre.

Skript zajišťuje pohyb míče, přehrávání zvuků, reset pozice a aktualizaci skóre.

## GameManager.cs
Proměnné:
- `scoreText`: Zobrazení skóre na obrazovce.
- `resetButton`: Tlačítko pro reset hry.
- `player1StartPosition`, `player2StartPosition`: Výchozí pozice hráčů.

Hráči a skóre:
- `scorePlayer1`, `scorePlayer2`: Skóre pro oba hráče.
- `gameEnded`: Stav hry (zda je ukončena).
- `player1`, `player2`: Hráči ve hře.

Funkce `Start()`:
- Najde hráče podle tagů a nastaví počáteční skóre.
- Skryje tlačítko pro reset.

Funkce `UpdateScore(string goalName)`:
- Zvyšuje skóre na základě toho, kdo vstřelil gól.
- Pokud skóre dosáhne 10 bodů, hra končí, jinak se aktualizuje skóre a resetují pozice hráčů.

Funkce `EndGame()`:
- Zastaví hru, zobrazí vítěze a aktivuje tlačítko reset.

Funkce `ResetGame()`:
- Resetuje skóre, znovu spustí hru a vrátí hráče na výchozí pozice.

Skript spravuje skóre, konec hry a resetování hry.
