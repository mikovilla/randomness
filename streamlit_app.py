import pandas as pd
import matplotlib.pyplot as plt
import streamlit as st

# Read the CSV file without headers and assign custom column names
column_names = ["Run#", "Deterministic QuickSort Time (ms)", "Randomized QuickSort Time (ms)"]
data = pd.read_csv("/data/runtime_results.csv", header=None, names=column_names)

# Check if the columns are loaded correctly (optional)
st.write(data.head(11))  # This will display the first 10 rows (excluding the header) of the data in Streamlit

# Streamlit title
st.title("QuickSort Performance Analysis")

# Create the figure and axes for plotting
fig, ax = plt.subplots(figsize=(10, 6))

# Plot the Deterministic and Randomized QuickSort execution times as a line plot
ax.plot(data["Run#"], data["Deterministic QuickSort Time (ms)"], marker='o', label="Deterministic QuickSort", color='blue')
ax.plot(data["Run#"], data["Randomized QuickSort Time (ms)"], marker='x', label="Randomized QuickSort", color='red')

# Label the axes
ax.set_xlabel("Run #")
ax.set_ylabel("Execution Time (ms)")

# Set the title of the plot
ax.set_title("Execution Time Comparison: Deterministic vs Randomized QuickSort")

# Show the legend
ax.legend()

# Display the plot in Streamlit
st.pyplot(fig)
