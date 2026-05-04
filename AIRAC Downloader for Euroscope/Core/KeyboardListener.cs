using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

public class KeyboardListener
{
    private static KeyboardListener? instance;
    private TaskCompletionSource<KeyResult>? keyTcs;

    public readonly struct KeyResult
    {
        public uint Code { get; }
        public string Name { get; }
        public bool IsExtended { get; }

        public KeyResult(uint code, string name, bool isExtended)
        {
            Code = code;
            Name = name;
            IsExtended = isExtended;
        }
    }

    public static KeyboardListener Instance
        => instance ??= new KeyboardListener();

    private KeyboardListener() { }

    // -----------------------------------------------------
    // ASYNC LISTENER
    // -----------------------------------------------------
    public Task<KeyResult?> ListenAsync(UserControl window, CancellationToken cancellationToken = default)
    {
        // Cancel when already listening
        if (keyTcs != null && !keyTcs.Task.IsCompleted)
        {
            keyTcs.TrySetCanceled();
            keyTcs = null;
            return Task.FromResult<KeyResult?>(null);
        }

        keyTcs = new TaskCompletionSource<KeyResult>(
            TaskCreationOptions.RunContinuationsAsynchronously);

        KeyEventHandler handler = null!;
        handler = (s, e) =>
        {
            if (keyTcs == null)
                return;

            int vk = KeyInterop.VirtualKeyFromKey(e.Key);
            uint scan = MapVirtualKey((uint)vk, 0);
            bool ext = IsExtendedKey(vk);

            uint code = (uint)(((scan & 0xFF) | (ext ? 0x100u : 0u)) << 16);
            string name = GetKeyName((ushort)scan, ext);

            window.KeyDown -= handler;
            keyTcs.TrySetResult(new KeyResult(code, name, ext));
        };

        window.KeyDown += handler;

        if (cancellationToken != default)
        {
            cancellationToken.Register(() =>
            {
                window.KeyDown -= handler;
                keyTcs?.TrySetCanceled();
            });
        }

        return keyTcs.Task.ContinueWith(t =>
        {
            if (t.IsCanceled)
                return (KeyResult?)null;

            return t.Result;
        });
    }

    // -----------------------------------------------------
    // EXTENDED KEY ERKENNUNG
    // -----------------------------------------------------
    private static bool IsExtendedKey(int vk)
    {
        return vk switch
        {
            0x21 or 0x22 or 0x23 or 0x24 or
            0x25 or 0x26 or 0x27 or 0x28 or
            0x2D or 0x2E or
            0x5B or 0x5C or 0x5D or
            0xA3 or 0xA5 => true,
            _ => false
        };
    }

    // -----------------------------------------------------
    // KEY NAME
    // -----------------------------------------------------
    public static string GetKeyName(ushort scanCode, bool isExtended)
    {
        int lParam = (scanCode << 16) | (isExtended ? 1 << 24 : 0);
        var sb = new StringBuilder(64);

        int len = GetKeyNameTextW(lParam, sb, sb.Capacity);
        return len > 0 ? sb.ToString() : $"Scan {scanCode}";
    }

    // -----------------------------------------------------
    // KEYRESULT
    // -----------------------------------------------------
    /// <summary>
    /// Receive Keyresult from scanCode only
    /// </summary>
    /// <param name="scanCode">The scan code of the key</param>
    /// <returns>A KeyResult object if the scanCode is valid</returns>
    public static KeyResult? GetKeyFromCode(uint scanCode)
    {
        ushort code = (ushort)((scanCode >> 16) & 0xFF);
        bool isExtended = ((scanCode >> 16) & 0x100) != 0;

        string name = GetKeyName(code, isExtended);

        return new KeyResult(code, name, isExtended);
    }

    // -----------------------------------------------------
    // NATIVE IMPORTS
    // -----------------------------------------------------
    [DllImport("user32.dll")]
    private static extern uint MapVirtualKey(uint uCode, uint uMapType);

    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    private static extern int GetKeyNameTextW(int lParam, StringBuilder lpString, int nSize);
}
