import csv
import json

# CONFIGURACIÓN

archivo_csv = r"C:\Users\USUARIO\Documents\UiPath\PruebaSinConexion\Prueba Técnica para el Cargo de Desarrollador RPA\Procesar PY\Seccion 3_Desarrollo en Python - Script de Procesamiento de Datos.csv"
archivo_salida = r"C:\Users\USUARIO\Documents\UiPath\PruebaSinConexion\Prueba Técnica para el Cargo de Desarrollador RPA\Procesar PY\resultado.json"
umbral_salario = 70000

# VARIABLES

total_registros = 0
suma_edades = 0
suma_salarios = 0
salarios_mayores = []

# LECTURA DEL CSV

try:
    with open(archivo_csv, mode="r", encoding="utf-8") as archivo:
        lector = csv.DictReader(archivo)

        for fila in lector:
            total_registros += 1

            edad = int(fila["Age"])
            salario = int(fila["Salary"])

            suma_edades += edad
            suma_salarios += salario

            if salario > umbral_salario:
                salarios_mayores.append({
                    "Name": fila["Name"],
                    "Salary": salario
                })

   
    # CÁLCULOS

    promedio_edad = suma_edades / total_registros if total_registros > 0 else 0
    promedio_salario = suma_salarios / total_registros if total_registros > 0 else 0


    # RESULTADO FINAL

    resultado = {
        "total_registros": total_registros,
        "promedio_edad": round(promedio_edad, 2),
        "promedio_salario": round(promedio_salario, 2),
        "empleados_con_salario_mayor_a_" + str(umbral_salario): salarios_mayores
    }

    # JSON

    with open(archivo_salida, mode="w", encoding="utf-8") as salida:
        json.dump(resultado, salida, indent=4)

    print("Proceso completado correctamente.")
    print("Archivo generado:", archivo_salida)

except Exception as e:
    print("Ocurrió un error:", e)
