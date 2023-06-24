import { Color, CssBaseline, useMediaQuery } from "@mui/material";
import { blue, red, teal } from "@mui/material/colors";
import React from "react";
import useLocalStorage from "../Hooks/useLocalStorage";
import { Theme, ThemeProvider } from "@emotion/react";
import { SimplePaletteColorOptions, TypeBackground } from "@mui/material/styles/createPalette";
import createTheme from "@mui/material/styles/createTheme";

const themeForEnvironment = {
	light: {
		primary: (): Partial<Color> | SimplePaletteColorOptions => {
			return blue;
		},
		secondary: (): Partial<Color> | SimplePaletteColorOptions => {
			return { main: "#3484bb" };
		},
		background: (): Partial<TypeBackground> => {
			return { default: "#f3f3f3" };
		},
	}, 
	dark: {
		primary: (): Partial<Color> | SimplePaletteColorOptions => {
			return teal;
		},
		secondary: (): Partial<Color> | SimplePaletteColorOptions => {
			return red;
		},
	},
};

const lightTheme = createTheme({
	palette: {
		mode: "light",
		primary: themeForEnvironment.light.primary(),
		secondary: themeForEnvironment.light.secondary(),
		background: themeForEnvironment.light.background(),
	},
	components:{
		MuiTextField: {
			defaultProps: {
				variant: "standard"
			}
		}
	}
});

const darkTheme = createTheme({
	palette: {
		mode: "dark",
		primary: themeForEnvironment.dark.primary(),
		secondary: themeForEnvironment.dark.secondary(),
	},
	components: {
		MuiTextField: {
			defaultProps: {
				variant: "standard"
			}
		},
		MuiCssBaseline: {
			styleOverrides: {
				"*": {
					"scrollbar-color": "#121212 #888"
				},
				"*::-webkit-scrollbar-track": {
					background: "#12121200"
				},
				"*::-webkit-scrollbar-thumb": {
					border: "3px solid #12121200"
				}
			}
		}
	}
});

type ThemeName = "light" | "dark" | "system";

export const AppThemeContext = React.createContext<[ThemeName, (theme: ThemeName) => void]>({} as any);

type Props = object;

export function AppThemeProvider(props: React.PropsWithChildren<Props>) {
	const prefersDarkMode = useMediaQuery("(prefers-color-scheme: dark)");
	const [themeName, setThemeName] = useLocalStorage<ThemeName>("PreferredAppTheme", "system");
	const [theme, setTheme] = React.useState<Theme>(lightTheme);

	React.useEffect(() => {
		if (themeName === "system") {
			setTheme(lightTheme);
		}
	}, [prefersDarkMode, themeName]);

	const onChangeTheme = (theme: ThemeName) => {
		if (theme === "light") {
			setTheme(lightTheme);
		} else if (theme === "dark") {
			setTheme(darkTheme);
		} else {
			setTheme(prefersDarkMode ? darkTheme : lightTheme);
		}
		setThemeName(theme);
	};

	return (
		<ThemeProvider theme={theme}>
			<CssBaseline />
			<AppThemeContext.Provider value={[themeName, onChangeTheme]}>
					{props.children}
			</AppThemeContext.Provider>
		</ThemeProvider>
	);
}

export default AppThemeProvider;