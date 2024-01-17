class Resistor:
    standard_values = [10, 11, 12, 13, 15, 16, 18, 20, 22, 24, 27, 30, 33, 36, 39, 43, 47, 51, 56, 62, 68, 75, 82, 91]

    def __init__(self):
        self.P = None  # Power in watts
        self.R = None  # Resistance in ohms
        self.I = None  # Current in amperes
        self.V = None  # Voltage in volts

    @classmethod
    def get_common_resistor(cls, calculated_resistance):
        if isinstance(calculated_resistance, (int, float)):
            calculated_resistance = int(calculated_resistance)
            first_two_digits = int(str(calculated_resistance)[:2])
            multiplier = 10 ** (len(str(calculated_resistance)) - 2)
            common_value = first_two_digits * multiplier

            closest_value = min(cls.standard_values, key=lambda x: abs(x - common_value))
            return closest_value
        else:
            raise ValueError("Calculated resistance must be a number")

    def set_resistance(self, calculated_resistance):
        self.R = self.get_common_resistor(calculated_resistance)
