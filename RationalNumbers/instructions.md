## Instructions

A rational number is defined as the quotient of two integers $a$ and $b$, called the numerator and denominator, respectively, where $b \neq 0$.

| Note |
| --- |
| Mathematically, the denominator can't be zero. |
| However in many implementations of rational numbers, you will find that the denominator is allowed to be zero with behaviour similar to positive or negative infinity in floating point numbers. |
| Even in those cases, the denominator and numerator generally can't both be zero. |

## Arithmetic

#### Absolute value

The absolute value $|r|$ of the rational number is equal to $r = a \div b$ $$\frac{|a|}{|b|}$$ 

---

#### Sum

The sum of two rational numbers $r₁ = a₁ \div b₁$ and $r₂ = a₂ \div b₂$ is $$r₁ + r₂ = \frac{a₁ \times b₁ + a₂ \times b₂}{b 1 \times b2}$$

---

#### Difference

The difference of two rational numbers $r₁ = a₁ \div b₁$ and $r₂ = a₂ \div b₂$ is $$r₁ - r₂ = \frac{a₁}{b₁} - \frac{a₂}{b₂} = \frac{(a₁ \times b₂ - a₂ \times b₁)}{(b₁ \times b₂)}$$

---

#### Product

The product (multiplication) of two rational numbers $r₁ = a₁ \div b₁$ and $r₂ = a₂ \div b₂$ is $$r₁ \times r₂ = \frac {(a₁ \times a₂)}{(b₁ \times b₂)}$$

---

#### Division

Dividing a rational number $r₁ = a₁ \div b₁$ by another $r₂ = a₂ \div b₂$ is $$r₁ \div r₂ = \frac {(a₁ \times b₂)}{ (a₂ \times b₁)}$$ 

*(if $a₂$ is not 0)*

---

#### Exponentiation (positive)

Exponentiation of a rational number $r = a \div b$ to a non-negative integer power $n$ is $$r^n = \frac{a^n}{b^n}$$

---

#### Exponentiation (negative)

Exponentiation of a rational number $r = a \div b$ to a negative integer power $n$ is $$r^n = \frac{b^m}{a^m}$$

(where $m = |n|$)

---

#### Exponentiation ($real => rational)$

Exponentiation of a rational number $r = a \div b$ to a real (floating-point) number $x$ is the quotient $$\frac {(a^x)}{(b^x)}$$

(which is a real number)

---

#### Exponentiation ($rational => real)$

Exponentiation of a real number $x$ to a rational number $r = a \div b$ is: 

$$x^{\frac{a}{b}} = \sqrt[b]{x^a}$$
    
where $\sqrt(p, q)$ is the $q^{th}$ root of $p$ => $\sqrt[q]{p}$

---
<br>

## Exercise

Implement the following operations on rational numbers:

- addition, subtraction, multiplication and division of two rational numbers
- absolute value
- exponentiation of a given rational number to an integer power
- exponentiation of a given rational number to a real (floating-point) power
- exponentiation of a real number to a rational number.

| Note |
|------|
| Your implementation of rational numbers should always be reduced to lowest terms. |

| Original | Simplified |
|:--------:|:----------:|
| $4/4$    | $\frac{1}{1}$ |
| $30/60$  | $\frac{1}{2}$ |
| $12/8$   | $\frac{3}{2}$ |
| etc...   ||

### Simplify a fraction

To reduce a rational number $r = a/b$, divide $a$ and $b$ by the greatest common divisor (GCD) of $a$ and $b$

#### Examples

$gcd(12, 8) = 4$
- Divide both numerator and denominator of $r = 12/8$ by 4
- $\frac{(12 \div 4)}{(8 \div 4)} = \frac{3}{2}$
- The simplified form of a rational number should be in `standard form`
    - *denominator should always be a positive integer*
- If the denominator has a negative value correct this by multiplying both numerator and denominator by $-1$
    - For example, $\frac{3}{-4}$ should be simplified to $\frac{-3}{4}$

Assume that the programming language you are using does not have an implementation of rational numbers.

---

### Source
[Wikipedia!\[The link opens in a new window or tab\](https://assets.exercism.org/assets/icons/external-link-49b422d65245eaf4cb29a072e85d73b5c6b8aa04.svg)](https://en.wikipedia.org/wiki/Rational_number)