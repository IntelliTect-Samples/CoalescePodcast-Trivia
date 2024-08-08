<template>
  <v-container>
    <h1>Question Editor</h1>

    <c-input :model="question" for="text" />
    <c-input :model="question" for="correctAnswer" />

    <h3>Answers</h3>
    <div v-for="answer in question.answers" :key="answer.$stableId">
      <c-input :model="answer" for="text" />
    </div>

    <v-btn @click="question.$bulkSave()"> Save </v-btn>
  </v-container>
</template>

<script setup lang="ts">
import { QuestionViewModel } from "@/viewmodels.g";

const props = defineProps<{
  id: string;
}>();

const question = new QuestionViewModel();
question.$load(props.id);
</script>
