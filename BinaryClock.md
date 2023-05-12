# NAME
    BinaryClock - Display a binary clock on the Sense HAT LED Matrix

## SYNOPSIS
    dotnet BinaryClock.dll [OPTIONS]

## DESCRIPTION
    The `BinaryClock` program displays a binary clock on the Sense HAT LED Matrix, allowing you to visualize the time using binary representation.

## OPTIONS
    -V, --vertical
        Display the clock in vertical format.

    -A, --ampm
        Display the clock in 12-hour mode with AM/PM indication.

    -h, --help
        Display this help message.

## MODES

### Vertical Format
By using the `-V` or `--vertical` option, the clock will be displayed in a vertical format on the Sense HAT LED Matrix. This format arranges the binary representation of time vertically, with each row representing a specific unit of time (hours, minutes, and seconds).

### 12-Hour Mode with AM/PM Indication
When the `-A` or `--ampm` option is used, the clock will be displayed in 12-hour mode with AM/PM indication on the Sense HAT LED Matrix. In this mode, the clock will indicate whether it is morning (AM) or afternoon/evening (PM) by coloring the corresponding LED lights. Green lights represent AM, while orange lights represent PM.

### Example Output
Example output on the Sense HAT LED Matrix (8x8 grid) in various modes at 8:39 PM:

$ dotnet BinaryClock.dll
○ ○ ○ ● ○ ● ○ ○
○ ○ ● ○ ○ ● ● ●
○ ○ ● ○ ● ○ ● ○
○ ○ ○ ○ ○ ○ ○ ○
○ ○ ○ ○ ○ ○ ○ ○
○ ○ ○ ○ ○ ○ ○ ○
○ ○ ○ ○ ○ ○ ○ ○
○ ○ ○ ○ ○ ○ ○ ○
The LEDs are white.

$ dotnet BinaryClock.dll -A
○ ○ ○ ○ ● ○ ○ ○
○ ○ ● ○ ○ ● ● ●
○ ○ ● ○ ● ○ ● ○
○ ○ ○ ○ ○ ○ ○ ○
○ ○ ○ ○ ○ ○ ○ ○
○ ○ ○ ○ ○ ○ ○ ○
○ ○ ○ ○ ○ ○ ○ ○
○ ○ ○ ○ ○ ○ ○ ○
The LEDs are orange.

$ dotnet BinaryClock.dll V
○ ○ ○ ○ ○ ○ ○ ○
○ ○ ○ ○ ○ ○ ○ ○
○ ○ ○ ○ ○ ● ○ ●
○ ○ ○ ● ○ ○ ○ ○
○ ○ ○ ○ ○ ○ ○ ●
○ ○ ○ ● ○ ● ○ ○
○ ○ ○ ○ ○ ● ○ ●
○ ○ ○ ○ ○ ● ○ ○
The LEDs are white.