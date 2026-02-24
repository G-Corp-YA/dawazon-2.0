#!/bin/bash

# ==============================
# Configuración base
# ==============================

BASE_DIR="$(cd "$(dirname "$0")" && pwd)"
ENVIRONMENT="Desarrollo"
FAIL_COUNT=0

# Orden específico de ejecución
CARPETAS=(
    "ControladorAuth"
    "ControladorProductos"
    "ControladorCarrito"
    "ControladorAdmin"
)

echo "Iniciando pruebas de Bruno..."
echo "Directorio base: $BASE_DIR"
echo "Entorno: $ENVIRONMENT"
echo "----------------------------------------"

# ==============================
# Verificar si Bruno CLI está instalado
# ==============================

if ! command -v bru &> /dev/null; then
    echo "Bruno CLI no está instalado. Instalándolo globalmente..."
    npm install -g @usebruno/cli
fi

# ==============================
# Ejecutar carpetas en orden
# ==============================

for CARPETA in "${CARPETAS[@]}"; do

    RUTA_CARPETA="$BASE_DIR/$CARPETA"
    REPORTE="$BASE_DIR/report-$CARPETA.json"

    echo ""
    echo "▶ Ejecutando carpeta: $CARPETA"
    echo "Ruta: $RUTA_CARPETA"

    if [ -d "$RUTA_CARPETA" ]; then
        bru run "$RUTA_CARPETA" --env "$ENVIRONMENT" --output "$REPORTE"

        if [ $? -ne 0 ]; then
            echo "Falló: $CARPETA"
            ((FAIL_COUNT++))
        else
            echo "$CARPETA pasó correctamente"
        fi
    else
        echo "La carpeta no existe: $RUTA_CARPETA"
        ((FAIL_COUNT++))
    fi

done

# ==============================
# Resumen final
# ==============================

echo ""
echo "========================================"
if [ $FAIL_COUNT -eq 0 ]; then
    echo "Todas las carpetas pasaron correctamente!"
else
    echo "$FAIL_COUNT carpeta(s) tuvieron errores."
fi
echo "========================================"

# Salida con código de error si hubo fallos (ideal para CI/CD)
exit $FAIL_COUNT