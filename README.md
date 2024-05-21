# Mensa gymnázium, o.p.s. - Maturitní zkouška z Informatiky 2024 - Zadání

## Pokyny
Níže najdete zadání čtyř úloh. Libovolné tři z nich naprogramujte ve vhodném programovacím jazyce, jednu můžete vynechat, nebo využít pro získání bonusových bodů. Na práci máte 240 minut, po přestávce pak 15 minut na obhajobu před komisí.

Komunikovat smíte pouze se zkoušejícím(i), ale jinak můžete používat internet (včetně AI), literaturu, knihovny, tutoriály, dokumentace, svoje vlastní poznámky, svůj vlastní kód apod.

Pište přehledný, komentovaný, čitelný kód. Nebojte se ptát zkoušejících, v nejhorším vám neodpovíme, nebo nabídneme popostrčení kupředu za cenu bodové ztráty.

Není-li předepsaný formát vstupu/výstupu, zvolte vhodnou reprezentaci dle vlastního uvážení, která vám umožní předvést funkčnost algoritmu při obhajobě (stdin-out, konzolová aplikace, GUI, ...).

### Odevzdání a obhajoba
Založte si privátní GitHub repozitář(e), do kterého **průběžně pushujte** postup své práce. Do repozitáře [**nastavte přístup (colaborator)**](https://docs.github.com/en/account-and-profile/setting-up-and-managing-your-github-user-account/managing-access-to-your-personal-repositories/inviting-collaborators-to-a-personal-repository) pro následující GitHub účty:
* `hakenr`
* `csgut` 

Při závěrečné obhajobě (15 min) bude vaším úkolem představit řešení a funkčnost jednotlivých úloh:
* vysvětlit stručně postup algoritmu,
* ukázat a popsat zdrojový kód (lze spojit s vysvětlováním algoritmu),
* předvést spustitelný a funkční program (musí být možné předat vstupy a ověřit výstupy)

Pamatujte na omezený čas obhajoby, na každou úlohu je max. 5 minut.

### Hodnocení
Za každou úlohu můžete získat 0-30 bodů, dalších 0-10 bodů pak můžete získat u obhajoby.
Výsledné hodnocení se určí takto:
* 86 a více bodů - výborné,
* 68 až 85 bodů - chvalitebné,
* 50 až 67 bodů - dobré,
* 33 až 49 bodů - dostatečné,
* 32 a méně bodů - nedostatečné - neuspěl(a)



## Úloha 1: Konečný automat pro validaci e-mailu
Navrhněte (nakreslete) a implementujte konečný automat, který rozpozná platné e-mailové adresy.

#### Vstup

* textový řetězec`t`

#### Výstup

* indikace (pozitivní/negativní), jestli je vstupní textový řetězec `t` platnou e-mailovou adresou

#### Příklad vstupu a výstupu

```
jan.novak@mensagymnazium.cz
true

jan.novak
false

jan@.cz
false
```



## Úloha 2: Určení nejjednodušší směny

Navrhněte optimální algoritmus a napište program, který určí nejkratší posloupnost směn měn na základě zadané tabulky možných směnných kurzů. Program by měl přijmout počáteční měnu a cílovou měnu a vrátit nejkratší posloupnost směn, která umožní převod z počáteční měny na cílovou měnu. Pokud je optimálních řešení více, stačí vypsat první nalezené.

#### Vstupy

* směnné kurzy měn
* počáteční měna
* cílová měna

#### Výstup

* posloupnost použitých směnných kurzů měn

#### Příklad vstupu a výstupu

```
[CZK, EUR, 25.3], [CZK, USD, 24.1], [EUR, USD, 0.95], [USD, JPY, 17.3], [HRK, NOK, 0.25], [EUR, NOK, 7.1]
CZK, NOK

[CZK, EUR], [EUR, NOK]
```



## Úloha 3: Počet jedniček v binární reprezentaci čísla

Napište program, který určí počet jedniček v binární reprezentaci zadaného celého kladného čísla.

#### Vstup

* kladné celé číslo `n` (`UInt64`)

#### Výstup

* počet jedniček v binární reprezentaci daného čísla (volitelně můžete binární reprezentaci vypsat)

#### Příklady vstupu a výstupu

```
1 => 1 (1)
857695 => 12 (11010001011001011111)
```



## Úloha 4: Validace struktury dokumentu

Napište program, který zkontroluje strukturu vstupního dokumentu. Dokument je složen z bloků, jejichž začátek je označen `{START:name}` a konec je označen `{END:name}`. Bloky mohou být vnořené, ale nesmí se křížit.

#### Formát značek

- Otevírací značky jsou ve formátu `{START:name}`, kde `name` je libovolný řetězec bez mezer.
- Zavírací značky jsou ve formátu `{END:name}`, kde `name` odpovídá otevíracímu tagu.

#### Vstup

* textový řetězec `t`, který představuje kontroloval dokument

#### Výstup

* indikace (pozitivní/negativní), jestli je vstupní textový řetězec správně strukturován

#### Příklady vstupu a výstupu

```
{START:outer}
	text
    {START:inner}text{END:inner}
{END:outer}

VALID
```

```
{START:outer}
    {START:inner}text
{END:outer}
    text{END:inner}
    
INVALID
```

*Poznámka*: Na textu mezi značkami ani na odsazení řádků v dokumentu nezáleží.
