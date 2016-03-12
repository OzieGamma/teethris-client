import teethris


keyboard = {teethris.F1:(teethris.ONE,teethris.TWO,teethris.F2),teethris.F2:(teethris.F1,teethris.F3,teethris.TWO,teethris.THREE),teethris.F3:(teethris.F2,teethris.F4,teethris.THREE,teethris.FOUR),teethris.F4:(teethris.F3,teethris.F5,teethris.FOUR,teethris.FIVE),teethris.F5:(teethris.F6,teethris.F4,teethris.SIX,teethris.SEVEN),teethris.F6:(teethris.F7,teethris.F5,teethris.SEVEN,teethris.EIGHT),teethris.F7:(teethris.F6,teethris.F8,teethris.EIGHT,teethris.NINE),teethris.F8:(teethris.F7,teethris.F9,teethris.NINE,teethris.ZERO),teethris.F9:(teethris.F10,teethris.F8,teethris.MINUS),teethris.F10:(teethris.F9,teethris.F11,teethris.EQUALS),teethris.F11:(teethris.F10,teethris.F12,teethris.BACKSPACE),teethris.F12:(teethris.F11,teethris.PRINT_SCREEN,teethris.BACKSPACE),teethris.PRINT_SCREEN:(teethris.F12,teethris.SCROLL_LOCK,teethris.INSERT),teethris.SCROLL_LOCK:(teethris.PRINT_SCREEN,teethris.PAUSE_BREAK,teethris.HOME),
            teethris.TILDE:(teethris.ONE,teethris.TAB),teethris.ONE:(teethris.F1,teethris.TILDE,teethris.TWO,teethris.Q,teethris.TAB),teethris.TWO:(teethris.F1,teethris.F2,teethris.ONE,teethris.THREE,teethris.Q,teethris.W),teethris.THREE:(teethris.F2,teethris.F3,teethris.TWO,teethris.FOUR,teethris.W,teethris.E),teethris.FOUR:(teethris.F3,teethris.F4,teethris.THREE,teethris.FIVE,teethris.E,teethris.R),teethris.FIVE:(teethris.F4,teethris.FOUR,teethris.SIX,teethris.R,teethris.T),teethris.SIX:(teethris.F5,teethris.FIVE,teethris.SEVEN,teethris.T,teethris.Y),teethris.SEVEN:(teethris.F5,teethris.F6,teethris.SIX,teethris.EIGHT,teethris.Y,teethris.U),teethris.EIGHT:(teethris.F6,teethris.F7,teethris.SEVEN,teethris.NINE,teethris.U,teethris.I),teethris.NINE:(teethris.F7,teethris.F8,teethris.EIGHT,teethris.ZERO,teethris.I,teethris.O),teethris.ZERO:(teethris.F8,teethris.NINE,teethris.MINUS,teethris.O,teethris.P),teethris.MINUS:(teethris.F9,teethris.ZERO,teethris.EQUALS,teethris.P,teethris.OPEN_BRACKET),teethris.EQUALS:(teethris.F10,teethris.MINUS,teethris.BACKSPACE,teethris.OPEN_BRACKET,teethris.CLOSE_BRACKET),teethris.BACKSPACE:(teethris.F11,teethris.F12,teethris.ENTER,teethris.CLOSE_BRACKET),teethris.INSERT:(teethris.PRINT_SCREEN,teethris.HOME,teethris.BACKSPACE,teethris.KEYBOARD_DELETE),teethris.HOME:(teethris.SCROLL_LOCK,teethris.INSERT,teethris.PAGE_UP,teethris.END),teethris.PAGE_UP:(teethris.PAUSE_BREAK,teethris.HOME,teethris.NUM_LOCK,teethris.PAGE_DOWN),teethris.NUM_LOCK:(teethris.PAGE_UP,teethris.NUM_SLASH,teethris.NUM_SEVEN),teethris.NUM_SLASH:(teethris.NUM_LOCK,teethris.NUM_ASTERISK,teethris.NUM_EIGHT),teethris.NUM_ASTERISK:(teethris.NUM_SLASH,teethris.NUM_MINUS,teethris.NUM_NINE),teethris.NUM_MINUS:(teethris.NUM_ASTERISK,teethris.NUM_PLUS),
            teethris.TAB:(teethris.TILDE,teethris.CAPS_LOCK,teethris.Q,teethris.ONE),teethris.Q:(teethris.TAB,teethris.W,teethris.ONE,teethris.TWO,teethris.CAPS_LOCK,teethris.A),teethris.W:(teethris.Q,teethris.E,teethris.TWO,teethris.THREE,teethris.A,teethris.S),teethris.E:(teethris.W,teethris.R,teethris.THREE,teethris.FOUR,teethris.S,teethris.D),teethris.R:(teethris.E,teethris.T,teethris.FOUR,teethris.FIVE,teethris.D,teethris.F),teethris.T:(teethris.R,teethris.Y,teethris.FIVE,teethris.SIX,teethris.F,teethris.G),teethris.Y:(teethris.T,teethris.U,teethris.SIX,teethris.SEVEN,teethris.G,teethris.H),teethris.U:(teethris.Y,teethris.I,teethris.SEVEN,teethris.EIGHT,teethris.H,teethris.J),teethris.I:(teethris.U,teethris.O,teethris.EIGHT,teethris.NINE,teethris.J,teethris.K),teethris.O:(teethris.I,teethris.P,teethris.NINE,teethris.ZERO,teethris.K,teethris.L),teethris.P:(teethris.O,teethris.OPEN_BRACKET,teethris.ZERO,teethris.MINUS,teethris.L,teethris.SEMICOLON),teethris.OPEN_BRACKET:(teethris.P,teethris.CLOSE_BRACKET,teethris.MINUS,teethris.EQUALS,teethris.SEMICOLON,teethris.APOSTROPHE),teethris.CLOSE_BRACKET:(teethris.OPEN_BRACKET,teethris.ENTER,teethris.EQUALS,teethris.BACKSPACE,teethris.APOSTROPHE,teethris.RIGHT_BACKSLASH),teethris.ENTER:(teethris.BACKSPACE,teethris.CLOSE_BRACKET,teethris.RIGHT_BACKSLASH,teethris.RIGHT_SHIFT,teethris.KEYBOARD_DELETE,teethris.ARROW_UP),teethris.KEYBOARD_DELETE:(teethris.ENTER,teethris.END,teethris.PAGE_DOWN,teethris.INSERT,teethris.ARROW_UP),teethris.END:(teethris.KEYBOARD_DELETE,teethris.PAGE_DOWN,teethris.HOME,teethris.ARROW_UP),teethris.NUM_SEVEN:(teethris.PAGE_DOWN,teethris.NUM_EIGHT,teethris.NUM_LOCK,teethris.NUM_FOUR),teethris.NUM_EIGHT:(teethris.NUM_SEVEN,teethris.NUM_NINE,teethris.NUM_SLASH,teethris.NUM_FIVE),teethris.NUM_NINE:(teethris.NUM_EIGHT,teethris.NUM_PLUS,teethris.NUM_ASTERISK,teethris.NUM_SIX),
            teethris.CAPS_LOCK:(teethris.TAB,teethris.LEFT_SHIFT,teethris.Q,teethris.A,teethris.LEFT_BACKSLASH),teethris.A:(teethris.CAPS_LOCK,teethris.Q,teethris.LEFT_BACKSLASH,teethris.S,teethris.W,teethris.Z),teethris.S:(teethris.A,teethris.D,teethris.W,teethris.Z,teethris.X,teethris.E),teethris.D:(teethris.S,teethris.E,teethris.R,teethris.F,teethris.C,teethris.X),teethris.F:(teethris.D,teethris.R,teethris.T,teethris.G,teethris.V,teethris.C),teethris.G:(teethris.F,teethris.T,teethris.Y,teethris.H,teethris.B,teethris.V),teethris.H:(teethris.G,teethris.Y,teethris.U,teethris.J,teethris.N,teethris.B),teethris.J:(teethris.H,teethris.U,teethris.I,teethris.K,teethris.M,teethris.N),teethris.K:(teethris.J,teethris.I,teethris.O,teethris.L,teethris.M,teethris.COMMA),teethris.L:(teethris.K,teethris.O,teethris.P,teethris.SEMICOLON,teethris.COMMA,teethris.PERIOD),teethris.SEMICOLON:(teethris.L,teethris.P,teethris.OPEN_BRACKET,teethris.APOSTROPHE,teethris.PERIOD,teethris.FORWARD_SLASH),teethris.APOSTROPHE:(teethris.SEMICOLON,teethris.OPEN_BRACKET,teethris.CLOSE_BRACKET,teethris.RIGHT_BACKSLASH,teethris.RIGHT_SHIFT,teethris.FORWARD_SLASH),teethris.RIGHT_BACKSLASH:(teethris.APOSTROPHE,teethris.CLOSE_BRACKET,teethris.ENTER,teethris.RIGHT_SHIFT),teethris.NUM_FOUR:(teethris.PAGE_DOWN,teethris.NUM_SEVEN,teethris.NUM_FIVE,teethris.NUM_ONE,teethris.ARROW_UP),teethris.NUM_FIVE:(teethris.NUM_FOUR,teethris.NUM_SIX,teethris.NUM_EIGHT,teethris.NUM_TWO),teethris.NUM_SIX:(teethris.NUM_FIVE,teethris.NUM_NINE,teethris.NUM_THREE,teethris.NUM_PLUS),teethris.NUM_PLUS:(teethris.NUM_MINUS,teethris.NUM_NINE,teethris.NUM_SIX),
            teethris.LEFT_SHIFT:(teethris.CAPS_LOCK,teethris.LEFT_CONTROL,teethris.LEFT_BACKSLASH),teethris.LEFT_BACKSLASH:(teethris.LEFT_SHIFT,teethris.LEFT_CONTROL,teethris.A,teethris.Z),teethris.Z:(teethris.LEFT_BACKSLASH,teethris.A,teethris.S,teethris.X,teethris.LEFT_ALT),teethris.X:(teethris.Z,teethris.S,teethris.D,teethris.C,teethris.LEFT_ALT,teethris.SPACE),teethris.C:(teethris.X,teethris.D,teethris.F,teethris.V,teethris.SPACE),teethris.V:(teethris.C,teethris.F,teethris.G,teethris.SPACE,teethris.B),teethris.B:(teethris.V,teethris.G,teethris.H,teethris.SPACE,teethris.N),teethris.N:(teethris.B,teethris.H,teethris.J,teethris.M,teethris.SPACE),teethris.M:(teethris.N,teethris.J,teethris.K,teethris.SPACE,teethris.COMMA),teethris.COMMA:(teethris.M,teethris.K,teethris.L,teethris.SPACE,teethris.PERIOD,teethris.RIGHT_ALT),teethris.PERIOD:(teethris.COMMA,teethris.L,teethris.SEMICOLON,teethris.FORWARD_SLASH,teethris.RIGHT_ALT),teethris.FORWARD_SLASH:(teethris.PERIOD,teethris.SEMICOLON,teethris.APOSTROPHE,teethris.RIGHT_SHIFT),teethris.RIGHT_SHIFT:(teethris.FORWARD_SLASH,teethris.APOSTROPHE,teethris.RIGHT_BACKSLASH,teethris.RIGHT_CONTROL,teethris.ARROW_UP),teethris.ARROW_UP:(teethris.RIGHT_SHIFT,teethris.ENTER,teethris.KEYBOARD_DELETE,teethris.END,teethris.PAGE_DOWN,teethris.NUM_FOUR,teethris.NUM_ONE,teethris.ARROW_DOWN),teethris.NUM_ONE:(teethris.ARROW_UP,teethris.NUM_FOUR,teethris.NUM_TWO,teethris.NUM_ZERO),teethris.NUM_TWO:(teethris.NUM_ONE,teethris.NUM_THREE,teethris.NUM_ZERO,teethris.NUM_FIVE),teethris.NUM_THREE:(teethris.NUM_TWO,teethris.NUM_SIX,teethris.NUM_PERIOD),
            teethris.LEFT_CONTROL:(teethris.LEFT_SHIFT,teethris.LEFT_BACKSLASH),teethris.LEFT_ALT:(teethris.Z,teethris.X,teethris.SPACE),teethris.SPACE:(teethris.LEFT_ALT,teethris.X,teethris.C,teethris.V,teethris.B,teethris.N,teethris.M,teethris.COMMA,teethris.RIGHT_ALT),teethris.RIGHT_ALT:(teethris.SPACE,teethris.COMMA,teethris.PERIOD),teethris.RIGHT_CONTROL:(teethris.RIGHT_SHIFT,teethris.ARROW_LEFT),teethris.ARROW_LEFT:(teethris.ARROW_DOWN,teethris.RIGHT_CONTROL),teethris.ARROW_DOWN:(teethris.ARROW_LEFT,teethris.ARROW_UP,teethris.ARROW_RIGHT),teethris.ARROW_RIGHT:(teethris.ARROW_DOWN,teethris.NUM_ZERO),teethris.NUM_ZERO:(teethris.NUM_PERIOD,teethris.NUM_ONE,teethris.NUM_TWO)}
    
def init():
    print("Starting")
    
    teethris.setLighting(teethris.LEFT_WINDOWS, 0, 100, 0)
    teethris.setLighting(teethris.LEFT_WINDOWS, 0, 0, 100)
    
    print(teethris.A)
    
def loop():
    print("Looping")
    
def on_key_press(key):
    teethris.setLighting(key, 0, 100, 0)
    keys = keyboard[key]
    for val in keys:
        print(" val: ", val)
        teethris.setLighting(val, 0, 30, 0)