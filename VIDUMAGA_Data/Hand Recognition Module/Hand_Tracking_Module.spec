# -*- mode: python ; coding: utf-8 -*-


block_cipher = None


a = Analysis(
    ['Hand_Tracking_Module.py'],
    pathex=[],
    binaries=[('C:\\Users\\User\\AppData\\Roaming\\Python\\Python311\\site-packages\\pywin32_system32\\pywintypes311.dll', '.'), ('C:\\Users\\User\\AppData\\Roaming\\Python\\Python311\\site-packages\\tensorflow\\python\\_pywrap_tensorflow_internal.pyd', '.')],
    datas=[('C:\\Users\\User\\AppData\\Roaming\\Python\\Python311\\site-packages\\mediapipe', 'mediapipe/')],
    hiddenimports=[],
    hookspath=[],
    hooksconfig={},
    runtime_hooks=[],
    excludes=[],
    win_no_prefer_redirects=False,
    win_private_assemblies=False,
    cipher=block_cipher,
    noarchive=False,
)
pyz = PYZ(a.pure, a.zipped_data, cipher=block_cipher)

exe = EXE(
    pyz,
    a.scripts,
    a.binaries,
    a.zipfiles,
    a.datas,
    [],
    name='Hand_Tracking_Module',
    debug=False,
    bootloader_ignore_signals=False,
    strip=False,
    upx=True,
    upx_exclude=[],
    runtime_tmpdir=None,
    console=False,
    disable_windowed_traceback=False,
    argv_emulation=False,
    target_arch=None,
    codesign_identity=None,
    entitlements_file=None,
)
