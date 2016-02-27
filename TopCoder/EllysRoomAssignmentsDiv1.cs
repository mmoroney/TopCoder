﻿// https://community.topcoder.com/stat?c=problem_statement&pm=12514

using System;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class EllysRoomAssignmentDiv1
    {
        public double getAverage(string[] ratings)
        {
            int[] parsedRatings = EllysRoomAssignmentDiv1.ParseRatings(ratings);
            int totalCount = parsedRatings.Length;
            int rooms = (totalCount - 1) / 20 + 1; 

            double regularSum = 0;
            double leftoverSum = 0;
            int i = 0;
            bool foundElly = false;

            foreach(int rating in parsedRatings.OrderByDescending(n => n))
            {
                if(rating == parsedRatings[0])
                {
                    foundElly = true;
                    leftoverSum = parsedRatings[0] * i;
                }

                leftoverSum += foundElly ? parsedRatings[0] : rating;
                i++;

                if (i == rooms)
                {
                    foundElly = false;
                    regularSum += leftoverSum;
                    leftoverSum = 0;
                    i = 0;
                }
            }

            int leftoverCount = parsedRatings.Length % rooms;
            double averageForSmallerRoom = (double)regularSum / (totalCount - leftoverCount);

            if (leftoverSum == 0)
                return averageForSmallerRoom;

            double averageLeftover = (double)leftoverSum / leftoverCount;
            int minPeople = parsedRatings.Length / rooms;

            double averageForLargerRoom = averageForSmallerRoom * minPeople / (minPeople + 1) + averageLeftover / (minPeople + 1);

            if (foundElly)
                return averageForLargerRoom;

            return averageForLargerRoom * leftoverCount / rooms + averageForSmallerRoom * (rooms - leftoverCount) / rooms;
        }

        private static int[] ParseRatings(string[] ratings)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ratings.Length; i++)
                sb.Append(ratings[i]);

            string[] tokens = sb.ToString().Split(' ');
            int[] parsedRatings = new int[tokens.Length];

            for (int i = 0; i < tokens.Length; i++)
                parsedRatings[i] = int.Parse(tokens[i]);

            return parsedRatings;
        }
    }

    [TestClass]
    public class EllysRoomAssignmentDiv1TestClass
    {
        [TestMethod]
        public void EllysRoomAssignmentDiv1Test()
        {
            EllysRoomAssignmentDiv1TestClass.EllysRoomAssignmentDiv1Test(
                new string[]
                {
                    "1924 1242 1213 1217 2399 1777 2201 2301 1683 2045 ",
                    "1396 2363 1560 2185 1496 2244 2117 2207 2098 1319 ",
                    "2216 1223 1256 2359 2394 1572 2151 2191 2147 2253 ",
                    "1633 2217 2211 1591 1310 1209 1430 1445 1988 2030 ",
                    "1947 1202 1203"
                }, 1821.3291005291007);

            EllysRoomAssignmentDiv1TestClass.EllysRoomAssignmentDiv1Test(
                new string[]
                {
                    "3380 3413 3254 3515 2885 2946 2790 3140"
                }, 3165.375);

            EllysRoomAssignmentDiv1TestClass.EllysRoomAssignmentDiv1Test(
                new string[]
                {
                    "2367 1395 1639 1842 1426 2393 2348 1571 2077 12", "2", "2 1966 1495 13",
                    "09 1251 3039 1566 1989 2083 1819 1875 ", "1579 2206 1503 1461 2262 2116 1429 2150 1834 2097 ",
                    "2093 1518 1923 1796 1669 2342 1826 2374 1635 1683 ", "1656 2190 1632 1946 1207 1293 2029 2243 2252 1559 ",
                    "2366 1590 1563 2319 1391 1255 1727 1565 1911 1679 ", "1282 2358 1682 2148 3555 2362 1208 2044 1949 1980 ",
                    "1983 2215 2184 1545 1665 2146 1272 2110 1889 1829 ", "1808 2065 1987 1297 2216 1609 1318 1816 1444 20", "00 1404"
                }, 1824.662456140351);

            EllysRoomAssignmentDiv1TestClass.EllysRoomAssignmentDiv1Test(
                new string[]
                {
                    "2869 3239 1609 2367 1836 1663 1697 2317 1475 2212 ", "2188 2073 1263 1391 1495 3010 1243 2198 1782 1564 ",
                    "3594 1219 2037 1473 1624 1435 2159 2315 2056 3029 ", "1863 1297 2245 3206 3510 1728 1246 1230 1875 3511 ",
                    "1241 2775 1255 2304 2013 1205 2070 2763 1518 2344 ", "1690 1398 2320 1912 2752 2155 1778 1644 2230 3026 ",
                    "1817 1401 1962 1470 1387 2339 3443 1510 2094 2374 ", "1273 1664 2853 1907 2380 3265 2786 1298 1983 1899 ",
                    "1507 3252 2176 1452 1261 1981 1570 1207 2107 3550 ", "1282 3331 1254 2276 2096 1716 1966 3389 1766 2068 ",
                    "3006 1802 1698 1555 1971 1509 1531 1556 2044 2358 ", "2327 2241 3182 2152 1514 2219 1559 1895 1992 2046 ",
                    "1200 1915 1930 2296 1859 1501 1960 1683 1222 1288 ", "1808 1360 2177 2711 1286 1562 2078 1801 1834 2808 ",
                    "1948 1674 1305 3031 2160 2252 1613 1621 2345 1850 ", "2169 2106 1918 1309 1317 1417 1670 2733 1946 1844 ",
                    "1774 1956 1355 1336 1300 1349 2283 1247 3258 3415 ", "2795 1978 1990 1394 2347 1337 1340 1503 1722 3528 ",
                    "2139 2968 2257 1312 2148 2166 1460 2216 1632 1325 ", "1404 1878 2197 1524 2030 1438 1973 1444 2191 1606 ",
                    "3390 1866 1688 1779 3027 2254 1582 2123 3105 1568 ", "2036 1579 2995 1591 1933 1382 1596 2364 3310 1856 ",
                    "3427 1816 1344 1304 3269 1906 1646 1480 2040 1725 ", "2766 1496 1265 2050 1842 2341 1367 1679 1202 1546 ",
                    "2300 1936 2224 1846 2987 2248 1657 2907 1958 1853 ", "3326 1943 3336 2801 2839 2357 1819 2266 1727 2200 ",
                    "2385 1904 1323 1710 1796 1594 2262 2798 1952 2292 ", "2204 1916 3572 1477 1280 1961 1270 1250 2000 2089 ",
                    "3584 1612 1873 1451 2004 3174 1251 3011 3474 2386 ", "1330 1758 1271 3540 1497 1284 1839 2383 1489 2326 ",
                    "2822 2124 2307 1313 3263 1804 2001 1338 2161 1303 ", "2016 1488 2015 1558 1522 2267 1567 1676 2221 1201 ",
                    "1576 1711 1887 2228 1539 1227 2392 2109 1616 2183 ", "2362 2784 2057 1411 1318 2097 1208 1672 1379 1339 ",
                    "1545 1461 3370 1369 1763 1425 1322 1897 1395 1209 ", "1665 2373 1645 1447 2393 1426 1293 1508 2049 2378 ",
                    "2234 1879 1949 1266 1849 3164 1260 2181 1611 1935 ", "1348 2021 3332 1820 1316 2261 3077 3328 1892 1324 ",
                    "2035 3251 1893 1910 1474 1557 2923 2024 2196 1571 ", "1980 2072 1924 2017 1770 2240 1659 3195 1486 3122 ",
                    "1341 1521 1890 1419 3229 1977 2366 1267 3458 2210 ", "2157 1523 1399 2146 1228 1415 1256 1642 1687 2184 ",
                    "1865 3089 3581 1429 2313 1352 1272 2285 1390 2209 ", "1785 1449 1295 1410 1239 1416 2354 1281 1840 2265 ",
                    "2330 3295 1353 1423 1204 2150 2116 3588 1908 1976 ", "2233 1923 1635 1825 1469 2251 1792 1249 2125 2100 ",
                    "1833 2281 2142 2093 1920 2144 1565 1590 2826 3045 ", "3475 1911 1695 2067 1634 2319 1376 2348 1529 1682"
                }, 1985.7041666666669);

            EllysRoomAssignmentDiv1TestClass.EllysRoomAssignmentDiv1Test(
                new string[]
                {
                    "1298 2272 2618 1344 3020 3212 3419 1754 3571 2835 ", "3049 2893 1970 3006 3244 3451 3273 2039 3826 2199 ", "3159"
                }, 2670.4545454545455);
        }

        private static void EllysRoomAssignmentDiv1Test(string[] ratings, double expected)
        {
            EllysRoomAssignmentDiv1 ellysRoomAssignmentDiv1 = new EllysRoomAssignmentDiv1();
            Assert.IsTrue(Math.Abs(expected - ellysRoomAssignmentDiv1.getAverage(ratings)) < 1e-9);
        }
    }
}
